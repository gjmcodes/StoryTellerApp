using StoryTeller.Core.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.GameContentDownload
{
    public interface IPageDownloadTasksService : IBaseService
    {
        Task<bool> DownloadPagesByCultureAsync(string culture);
    }
}
