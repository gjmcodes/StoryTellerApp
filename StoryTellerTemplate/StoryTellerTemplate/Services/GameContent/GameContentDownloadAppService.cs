using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.GameSettings;
using StoryTeller.Core.Interfaces.Services.GameContentDownload;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Services.GameContent
{
    public class GameContentDownloadAppService : BaseAppService
    {
        private readonly IPageDownloadTasksService _pageDownloadTasksService;
        private readonly INameCallDownloadTasksService _nameCallDownloadTasksService;

        private readonly IGameSettingsLocalReadOnlyRepository _gameSettingsLocalReadOnlyRepository;
        private readonly IPageExternalRepository _pageExternalRepository;

        int numOfTasks;
        int numOfCompleteTasks;

        public async Task  DownloadGameContentForCultureAsync()
        {
            var tasks = new List<Task>();
            var selectedCulture = await _gameSettingsLocalReadOnlyRepository.GetSelectedCultureAsync();

            var pagesTask = _pageExternalRepository.GetPagesByCultureAsync(selectedCulture);
            var pronoumNameCalls = _nameCallDownloadTasksService.DownloadPronoumNameCallsByCultureAsync(selectedCulture);
        }
    }
}
