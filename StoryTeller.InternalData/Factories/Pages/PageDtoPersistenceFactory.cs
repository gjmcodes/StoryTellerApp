using StoryTeller.Core.Models.Pages.DTOs;
using StoryTeller.Core.Pages;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTeller.InternalData.Interfaces.Factories.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Factories.Pages
{
    public class PageDtoPersistenceFactory : BaseLocalDataFactory, IPageDtoPersistenceFactory
    {
        private readonly IPageContentPersistenceFactory _pageContentPersistenceFactory;
        private readonly IPageActionPersistenceFactory _pageActionPersistenceFactory;

        public PageDtoPersistenceFactory(
            IPageContentPersistenceFactory pageContentPersistenceFactory, 
            IPageActionPersistenceFactory pageActionPersistenceFactory)
        {
            _pageContentPersistenceFactory = pageContentPersistenceFactory;
            _pageActionPersistenceFactory = pageActionPersistenceFactory;
        }

        public async Task<TranslatedPageDto> MapPageDtoToTranslatedAsync(PageDto pageDto, IEnumerable<PageActionDto> pageActions, IEnumerable<PageContentDto> pageContents)
        {
            var translatedPage = new TranslatedPageDto();
            translatedPage.PageId = pageDto.PageId;

            var gameActions = await _pageActionPersistenceFactory.MapDtoToGameActionAsync(pageActions);
            var translatedContents = await _pageContentPersistenceFactory.MapPageContentDtoToTextSpanAsync(pageContents);

            translatedPage.PageActions = gameActions;
            translatedPage.TranslatedContent = translatedContents;

            return translatedPage;
        }

        public async Task<PageDto> MapPageToDtoAsync(Page page)
        {
            return await Task.Run(() =>
            {

                var pageDto = new PageDto();
                pageDto.Content = page.content.content;
                pageDto.PageId = page.pageId;

                return pageDto;
            });
        }

        public async Task<IEnumerable<PageDto>> MapPageToDtoAsync(IEnumerable<Page> pages)
        {
            var dtos = new List<PageDto>();

            foreach (var item in pages)
            {
                dtos.Add(await MapPageToDtoAsync(item));
            }

            return dtos;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
