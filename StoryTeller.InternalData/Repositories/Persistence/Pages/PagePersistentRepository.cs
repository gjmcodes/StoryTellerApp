﻿using StoryTeller.Core.Interfaces.Repositories.Local.Pages;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.Pages;
using StoryTeller.InternalData.Interfaces.Factories.Pages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Repositories.Persistence.Pages
{
    public class PagePersistentRepository : BaseRepository, IPageLocalRepository
    {
        private readonly IContentMarkupTranslatorService _contentMarkupTranslatorService;

        private readonly IPageDtoPersistenceFactory _pageDtoPersistenceFactory;
        private readonly IPageActionPersistenceFactory _pageActionPersistenceFactory;
        private readonly IPageContentPersistenceFactory _pageContentPersistenceFactory;

        public async Task<bool> AddAsync(IEnumerable<Page> entities)
        {
            try
            {
                await Conn.RunInTransactionAsync(async (conn) =>
                {
                    conn.BeginTransaction();

                    foreach (var page in entities)
                    {
                        var pageDto = await _pageDtoPersistenceFactory.MapPageToDtoAsync(page);


                        var pageContents = await _contentMarkupTranslatorService.TranslateAsync(page.content.content);
                        var pageContentsDto = await _pageContentPersistenceFactory.MapPageContentToDtoAsync(pageContents, page.pageId);

                        var pageActionsDto = await _pageActionPersistenceFactory.MapPageActionToDtoAsync(page.actions);

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
                return false;
            }

        }

    }
}
