using StoryTeller.Core.Models.Pages.DTOs;
using StoryTeller.Core.Pages;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Models.GameContent;
using StoryTellerTemplate.Models.MainPage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTellerTemplate.Factories
{
    public class PageVmFactory : BaseFactory, IPageVmFactory
    {
        private readonly ITextSpanFactory _textSpanFactory;
        private readonly IGameActionVmFactory _gameActionVmFactory;

        public PageVmFactory(ITextSpanFactory textSpanFactory,
            IGameActionVmFactory gameActionVmFactory)
        {
            _gameActionVmFactory = gameActionVmFactory;
            _textSpanFactory = textSpanFactory;
        }

        public async Task<PageVm> MapDtoToPageVmAsync(PageDto dto,
            IEnumerable<PageActionDto> pageActions,
            IEnumerable<PageContentDto> pageContent)
        {
            var pagevm = new PageVm();

            var pgActionsTask = await _gameActionVmFactory.MapGameActionDtoToVmAsync(pageActions);
            pagevm.Actions = pgActionsTask.ToList();

            var pgContentTask = await _textSpanFactory.MapContentDtoToSpanAsync(pageContent);
            pagevm.Content = pgContentTask.ToList();

            return pagevm;
        }

        public PageVm MapPageToPageVm(StoryTeller.Core.Pages.Page page)
        {
            var pageVm = new PageVm();

            var pgActionTask = _gameActionVmFactory.MapGameActionToVm(page.actions);
            pageVm.Actions = pgActionTask.ToList();

            return pageVm;
        }

        public async Task<PageVm> MapTranslatedPageDtoToPageVmAsync(TranslatedPageDto translatedPageDto)
        {
            return await Task.Run(() =>
            {

                var pageVm = new PageVm();
                pageVm.Title = translatedPageDto.Title;
                pageVm.Image = translatedPageDto.Image;

                pageVm.Content = new List<Span>();

                var pageActions = _gameActionVmFactory.MapGameActionToVm(translatedPageDto.PageActions);
                pageVm.Actions = pageActions.ToList();

                var pageContents = _textSpanFactory.MapTextSpanToXamarinSpan(translatedPageDto.TranslatedContent);
                pageVm.Content = pageContents.ToList();

                return pageVm;
            });
        }

        protected override void ReleaseResources()
        {
            _textSpanFactory.Dispose();
            _gameActionVmFactory.Dispose();
            base.ReleaseResources();
        }
    }
}
