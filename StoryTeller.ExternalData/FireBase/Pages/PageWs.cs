﻿using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.Users;
using StoryTeller.Core.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.Pages
{
    public class PageWs : BaseFirebaseWs, IPageExternalRepository
    {
        public PageWs(IUserStatusLocalReadOnlyRepository userStatusLocalRepository) 
            : base("Pages", userStatusLocalRepository)
        {
        }

        public Task<bool> AddAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync<T>(IEnumerable<T> entities) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<Page> GetPageByIdAsync(string pageId)
        {
            var page = await base.GetByKeyWithLanguageAsync<Page>(nameof(pageId), pageId);

            return page.First();
        }

        public Task<IEnumerable<Page>> GetPagesByCultureAsync(string culture)
        {
            throw new NotImplementedException();
        }

        protected override void ReleaseResources()
        {
        }
    }
}
