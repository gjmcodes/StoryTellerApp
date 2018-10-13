using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Interfaces.Services.GameContentDownload;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Services.GameContent
{
    public class GameContentDownloadAppService : BaseAppService, IGameContentDownloadAppService
    {
        private readonly IPageDownloadTasksService _pageDownloadTasksService;
        private readonly INameCallDownloadTasksService _nameCallDownloadTasksService;
        private readonly IUserStatusLocalRepository _userStatusLocalRepository;

        private readonly IPageExternalRepository _pageExternalRepository;


        public async Task  DownloadGameContentForCultureAsync()
        {
            var tasks = new List<Task>();
            var selectedCulture = await _userStatusLocalRepository.GetSelectedCultureAsync();

            var pagesTask = _pageExternalRepository.GetPagesByCultureAsync(selectedCulture);
            var pronoumNameCalls = _nameCallDownloadTasksService.DownloadPronoumNameCallsByCultureAsync(selectedCulture);
        }

        public async Task<bool> HasLocalContentAsync()
        {
            return false;
        }
    }
}
