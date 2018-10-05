using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.GameSettings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Services.GameContent
{
    public class GameContentDownloadAppService : BaseAppService
    {
        private readonly IGameSettingsLocalReadOnlyRepository _gameSettingsLocalReadOnlyRepository;
        private readonly IPageExternalRepository _pageExternalRepository;
        int numOfTasks;
        int numOfCompleteTasks;

        public async Task  DownloadGameContentForCultureAsync()
        {
            var selectedCulture = await _gameSettingsLocalReadOnlyRepository.GetSelectedCultureAsync();

            var tasks = new List<Task>();
            var pagesTask = _pageExternalRepository.GetPagesByCultureAsync(selectedCulture)
                .ContinueWith((res) =>
            {
                numOfCompleteTasks++;
            });
        }
    }
}
