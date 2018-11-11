﻿using StoryTeller.Core.Models.Pronoums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.GameContentDownload
{
    public interface INameCallDownloadTasksService : IBaseService
    {
        Task<bool> DownloadPronoumNameCallsByCultureAsync(string culture);
    }
}
