﻿using StoryTeller.Core.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.External.Pages
{
    public interface IPageExternalRepository
    {
        Task<Page> GetPageByIdAsync(string pageId);
        Task<IEnumerable<Page>> GetPagesByCultureAsync();
    }
}
