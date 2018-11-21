using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Navigation;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Xamarin.Domain.Interfaces.Services.LocalData;
using StoryTellerTemplate.Interfaces.Services.CultureSelection;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Models.ContentDownload;
using StoryTellerTemplate.Models.GameCultures;
using StoryTellerTemplate.Navigations;
using StoryTellerTemplate.ViewsParameters;
using Xamarin.Forms;

namespace StoryTellerTemplate.ViewModels
{
    public class CultureSelectionPageViewModel : ViewModelBase
    {
        private bool _isCalledAsMenuOption;

        private readonly ICultureSelectionAppService _cultureSelectionAppService;
        private readonly ILocalDataManagementService _localDataManagementService;
        private readonly IGameContentDownloadAppService _gameContentDownloadAppService;

        public ObservableCollection<CultureVm> Cultures { get; }

        public CultureSelectionPageViewModel(INavigationService navigationService,
            ICultureSelectionAppService cultureSelectionAppService,
            ILocalDataManagementService localDataManagementService,
            IGameContentDownloadAppService gameContentDownloadAppService) : base(navigationService)
        {
            _cultureSelectionAppService = cultureSelectionAppService;
            _localDataManagementService = localDataManagementService;
            _gameContentDownloadAppService = gameContentDownloadAppService;

            DownloadProgress = new DownloadProgress();
            Cultures = new ObservableCollection<CultureVm>();
            SelectCultureCommand = new Command<CultureVm>(async (culture) => await SelectCultureAsync(culture));
        }

        public Command<CultureVm> SelectCultureCommand { get; }
        DownloadProgress _downloadProgress;
        public DownloadProgress DownloadProgress
        {
            get => _downloadProgress;
            set => SetProperty(ref _downloadProgress, value);
        }

        async Task NavigateToGameMasterPageAsync()
        {
            await NavigationService.NavigateAsync(new Uri(NavigationConstants.appAddress + "GameMasterPage/NavigationPage/GamePage"));
        }

        async Task NavigateToCharacterCreationPage()
        {
            await NavigationService.NavigateAsync(new Uri(NavigationConstants.appAddress + "CharacterCreationPage"));
        }

        public async Task SelectCultureAsync(CultureVm selectedCulture)
        {
            DownloadProgress.ProgressBarIsVisible = true;
            PageIsBusy = true;

            var cultureResult = await _cultureSelectionAppService.SetSelectedCultureAsync(selectedCulture.CultureCode);
            await _localDataManagementService.ClearLocalDataForCulctureChangeAsync();
            var contentDownloadResult = await _gameContentDownloadAppService.DownloadGameContentForCultureAsync(DownloadProgress);

            if (_isCalledAsMenuOption)
                await NavigateToGameMasterPageAsync();
            else
                await NavigateToCharacterCreationPage(); 

            DownloadProgress.ProgressBarIsVisible = false;
            PageIsBusy = false;
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey(ParametersKeys.model))
            {
                var viewParams = (CultureSelectionParams)parameters[ParametersKeys.model];
                _isCalledAsMenuOption = viewParams.IsCalledAsMenuOption;
            }

            var cultures = await _cultureSelectionAppService.GetCulturesAsync();

            Cultures.Clear();


            foreach (var item in cultures)
            {
                Cultures.Add(item);
            }
        }
    }
}
