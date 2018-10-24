using StoryTeller.Core.Interfaces.Repositories.Local.Pages;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.Models.Pages.DTOs;
using StoryTeller.Core.Pages;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTeller.InternalData.Interfaces.Factories.Pages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Repositories.Pages
{
    public class PageRepository : BaseRepository, IPageLocalRepository
    {
        private readonly IContentMarkupTranslatorService _contentMarkupTranslatorService;

        private readonly IPageDtoPersistenceFactory _pageDtoPersistenceFactory;
        private readonly IPageActionPersistenceFactory _pageActionPersistenceFactory;
        private readonly IPageContentPersistenceFactory _pageContentPersistenceFactory;

        public PageRepository(
            IContentMarkupTranslatorService contentMarkupTranslatorService, 
            IPageDtoPersistenceFactory pageDtoPersistenceFactory, 
            IPageActionPersistenceFactory pageActionPersistenceFactory, 
            IPageContentPersistenceFactory pageContentPersistenceFactory)
        {
            _contentMarkupTranslatorService = contentMarkupTranslatorService;
            _pageDtoPersistenceFactory = pageDtoPersistenceFactory;
            _pageActionPersistenceFactory = pageActionPersistenceFactory;
            _pageContentPersistenceFactory = pageContentPersistenceFactory;
        }

        public async Task<bool> AddPagesFromExternalDownloadAsync(IEnumerable<Page> entities)
        {
            try
            {

                    await Conn.DeleteAllAsync<PageDto>();
                    await Conn.DeleteAllAsync<PageActionDto>();
                    await Conn.DeleteAllAsync<PageContentDto>();

                    foreach (var page in entities)
                    {
                        var pageDto = await _pageDtoPersistenceFactory.MapPageToDtoAsync(page);


                        var pageContents = await _contentMarkupTranslatorService.TranslateAsync(page.content.content);
                        var pageContentsDto = await _pageContentPersistenceFactory.MapPageContentToDtoAsync(pageContents, page.pageId);

                        var pageActionsDto = await _pageActionPersistenceFactory.MapPageActionToDtoAsync(page.actions, page.pageId);

                        await Conn.InsertAsync(pageDto);
                        await Conn.InsertAllAsync(pageActionsDto);
                        await Conn.InsertAllAsync(pageContentsDto);
                    }


                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<TranslatedPageDto> GetPageByIdAsync(string pageId)
        {
            var pageData = await base.Conn.GetAsync<PageDto>(x => x.PageId == pageId);
            var pageActions = await base.Conn.Table<PageActionDto>().Where(x => x.PageId == pageId).ToArrayAsync();
            var pageContent = await base.Conn.Table<PageContentDto>().Where(x => x.PageId == pageId).ToArrayAsync();

            pageData.PageActionsDtos = pageActions;
            pageData.PageContentDtos = pageContent;

            var translatedPage = await _pageDtoPersistenceFactory.MapPageDtoToTranslatedAsync(pageData, pageActions, pageContent);

            return translatedPage;
        }

        public async Task<PageDto> GetPageDtoByIdAsync(string pageId)
        {
            var pageData = await base.Conn.GetAsync<PageDto>(x => x.PageId == pageId);
            var pageActions = await base.Conn.Table<PageActionDto>().Where(x => x.PageId == pageId).ToArrayAsync();
            var pageContent = await base.Conn.Table<PageContentDto>().Where(x => x.PageId == pageId).ToArrayAsync();

            pageData.PageActionsDtos = pageActions;
            pageData.PageContentDtos = pageContent;

            return pageData;
        }
    }
}
