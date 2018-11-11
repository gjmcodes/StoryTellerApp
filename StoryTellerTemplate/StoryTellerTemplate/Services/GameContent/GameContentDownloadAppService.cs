using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Interfaces.Services.GameContentDownload;
using StoryTeller.Core.Services.GameContentDownload;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Interfaces.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Services.GameContent
{
    public class GameContentDownloadAppService : BaseAppService, IGameContentDownloadAppService
    {
        private readonly IGameContentDownloadService _gameContentDownloadService;

        public GameContentDownloadAppService(IGameContentDownloadService gameContentDownloadService)
        {
            _gameContentDownloadService = gameContentDownloadService;
        }

        public async Task<bool> DownloadGameContentForCultureAsync(IContentDownloader contentDownloader)
        {
            var tasks = new List<Task<bool>>();

            contentDownloader.SetAmountOfTasks(_gameContentDownloadService.GetAmountOfTasks());

            tasks.Add(_gameContentDownloadService.DownloadAppDictionaryAsync()
               .ContinueWith((result) =>
               {
                   contentDownloader.UpdateProgress();
                   return true;
               }));
            tasks.Add(_gameContentDownloadService.DownloadGamePagesAsync().ContinueWith((result) =>
            {
                contentDownloader.UpdateProgress();
                return true;
            }));
            tasks.Add(_gameContentDownloadService.DownloadPronoumsAsync()
               .ContinueWith((result) =>
               {
                   contentDownloader.UpdateProgress();
                   return true;
               }));

            await Task.WhenAll(tasks);

            return tasks.All(x => x.Result);
        }

        public async Task<bool> HasLocalContentAsync()
        {
            return false;
        }
    }
}
