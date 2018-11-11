using StoryTeller.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.GameContentDownload
{
    public interface IGameContentDownloadService : IBaseService
    {
        int GetAmountOfTasks();
        IEnumerable<Task<bool>> GetDownloadTasks();
        Task<bool> DownloadAppDictionaryAsync();
        Task<bool> DownloadGamePagesAsync();
        Task<bool> DownloadPronoumsAsync();
    }
}
