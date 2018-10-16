using Prism.Navigation;
using StoryTellerTemplate.Interfaces.Services.GameContent;

namespace StoryTellerTemplate.ViewModels
{
    public class GameContentLoaderPageViewModel : ViewModelBase
	{
        private readonly IGameContentDownloadAppService _gameContentDownloadAppService;
        public GameContentLoaderPageViewModel(INavigationService navigationService,
            IGameContentDownloadAppService gameContentDownloadAppService) 
            : base(navigationService)
        {
            _gameContentDownloadAppService = gameContentDownloadAppService;
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            _gameContentDownloadAppService.DownloadGameContentForCultureAsync();

            base.OnNavigatedTo(parameters);
        }
    }
}
