using Prism.Navigation;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Models.ContentDownload;
using System.Threading.Tasks;

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
            DownloadProgress = new DownloadProgress();
        }

        DownloadProgress _downloadProgress;
        public DownloadProgress DownloadProgress
        {
            get => _downloadProgress;
            set => SetProperty(ref _downloadProgress, value);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            var result = await _gameContentDownloadAppService.DownloadGameContentForCultureAsync(DownloadProgress);

            await Task.Delay(2000);

            await NavigationService.NavigateAsync("CharacterCreationPage");
        }
    }
}
