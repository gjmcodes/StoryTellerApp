using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Interfaces.Services.GameContentDownload;
using StoryTellerTemplate.Interfaces.Services.GameContent;
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

        public async Task<bool> DownloadGameContentForCultureAsync()
        {
            var tasks = new List<Task>();
            var selectedCulture = await _userStatusLocalRepository.GetSelectedCultureAsync();

            var pagesTask = _pageDownloadTasksService.DownloadPagesByCultureAsync(selectedCulture);

            var pronoumNameCallsTask = _nameCallDownloadTasksService.DownloadPronoumNameCallsByCultureAsync(selectedCulture);

            var awaitAllTask = await Task.WhenAll(pagesTask, pronoumNameCallsTask);

            return awaitAllTask.All(x => x);
        }

        public async Task<bool> HasLocalContentAsync()
        {
            return false;
        }
    }
}
