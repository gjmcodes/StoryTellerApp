using Prism.Navigation;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Models.ContentDownload;

namespace StoryTellerTemplate.ViewModels
{
    public class GameContentLoaderPageViewModel : ViewModelBase, IContentDownloader
	{
        private readonly IGameContentDownloadAppService _gameContentDownloadAppService;
        public GameContentLoaderPageViewModel(INavigationService navigationService,
            IGameContentDownloadAppService gameContentDownloadAppService) 
            : base(navigationService)
        {
            _gameContentDownloadAppService = gameContentDownloadAppService;
            _downloadProgress = new DownloadProgress();
        }

        DownloadProgress _downloadProgress;
        public DownloadProgress DownloadProgress
        {
            get => _downloadProgress;
            set => SetProperty(ref _downloadProgress, value);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            _gameContentDownloadAppService.DownloadGameContentForCultureAsync();

            base.OnNavigatedTo(parameters);
        }
    }
}
