using StoryTeller.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.GameContentDownload
{
    public interface IGameContentDownloadService : IBaseService
    {
        int GetAmountOfTasks();
        Task<bool> DownloadAppDictionaryAsync();
        Task<bool> DownloadGamePagesAsync();
        Task<bool> DownloadPronoumsAsync();
    }
}
