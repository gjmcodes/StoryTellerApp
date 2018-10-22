using StoryTeller.Core.Pages;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Models.MainPage;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            pagevm.Actions = await _gameActionVmFactory.MapGameActionDtoToVmAsync(pageActions);
            pagevm.Content = await _textSpanFactory.MapContentDtoToSpanAsync(pageContent);

            return pagevm;
        }

        public PageVm MapPageToPageVm(Page page)
        {
            var pageVm = new PageVm();
            pageVm.Actions = _gameActionVmFactory.MapGameActionToVm(page.actions);

            return pageVm;
        }

        protected override void ReleaseResources()
        {
            _textSpanFactory.Dispose();
            _gameActionVmFactory.Dispose();
            base.ReleaseResources();
        }
    }
}
