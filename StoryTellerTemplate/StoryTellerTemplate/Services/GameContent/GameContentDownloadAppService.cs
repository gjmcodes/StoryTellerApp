using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Interfaces.Services.GameContentDownload;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Interfaces.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Services.GameContent
{
    public class GameContentDownloadAppService : BaseAppService, IGameContentDownloadAppService
    {
        private readonly IPageDownloadTasksService _pageDownloadTasksService;
        private readonly INameCallDownloadTasksService _nameCallDownloadTasksService;
        private readonly IUserStatusLocalRepository _userStatusLocalRepository;

        public GameContentDownloadAppService(IPageDownloadTasksService pageDownloadTasksService,
            INameCallDownloadTasksService nameCallDownloadTasksService, 
            IUserStatusLocalRepository userStatusLocalRepository)
        {
            _pageDownloadTasksService = pageDownloadTasksService;
            _nameCallDownloadTasksService = nameCallDownloadTasksService;
            _userStatusLocalRepository = userStatusLocalRepository;
        }

        public async Task<bool> DownloadGameContentForCultureAsync(IContentDownloader contentDownloader)
        {
            var tasks = new List<Task<bool>>();

            contentDownloader.SetAmountOfTasks(2);

            var selectedCulture = await _userStatusLocalRepository.GetSelectedCultureAsync();

            tasks.Add(_pageDownloadTasksService.DownloadPagesByCultureAsync(selectedCulture)
                .ContinueWith((result) =>
                {
                    contentDownloader.UpdateProgress();
                    return true;
                }));

            tasks.Add(_nameCallDownloadTasksService.DownloadPronoumNameCallsByCultureAsync(selectedCulture)
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
