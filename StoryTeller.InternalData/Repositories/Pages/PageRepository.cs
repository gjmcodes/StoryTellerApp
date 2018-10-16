﻿using StoryTeller.Core.Interfaces.Repositories.Local.Pages;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
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
                await Conn.RunInTransactionAsync(async (conn) =>
                {
                    conn.DeleteAll<PageDto>();
                    conn.DeleteAll<PageActionDto>();
                    conn.DeleteAll<PageContentDto>();

                    foreach (var page in entities)
                    {
                        var pageDto = await _pageDtoPersistenceFactory.MapPageToDtoAsync(page);


                        var pageContents = await _contentMarkupTranslatorService.TranslateAsync(page.content.content);
                        var pageContentsDto = await _pageContentPersistenceFactory.MapPageContentToDtoAsync(pageContents, page.pageId);

                        var pageActionsDto = await _pageActionPersistenceFactory.MapPageActionToDtoAsync(page.actions, page.pageId);

                        conn.Insert(pageDto);
                        conn.InsertAll(pageActionsDto);
                        conn.InsertAll(pageContentsDto);
                    }

                    conn.Commit();
                });

                return true;
            }
            catch (Exception e)
            {
                e = e;

                return false;
            }

        }

    }
}
