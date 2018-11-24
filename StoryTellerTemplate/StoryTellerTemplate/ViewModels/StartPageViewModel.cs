using Prism.Navigation;
using StoryTeller.Core.Services.GameContentDownload;
using StoryTeller.Xamarin.Domain.Interfaces.Services.LocalData;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Models.ContentDownload;
using StoryTellerTemplate.Navigations;
using System;
using Xamarin.Essentials;

namespace StoryTellerTemplate.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {

        private readonly ILocalDataManagementService _localDataManagementService;

        public StartPageViewModel(INavigationService navigationService,
            ILocalDataManagementService localDataManagementService)
            : base(navigationService)
        {
            DownloadProgress = new DownloadProgress();

            _localDataManagementService = localDataManagementService;
        }

        public DownloadProgress DownloadProgress { get; }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Unknown
                || Connectivity.NetworkAccess == NetworkAccess.None)
                await NavigationService.NavigateAsync("InternetConnectionRequiredPage");
            else
            {
                PageIsBusy = true;

                var hasLocalTables = await _localDataManagementService.HasLocalTablesAsync();

                if (!hasLocalTables)
                {
                    await _localDataManagementService.CreateLocalTablesAsync();

                    await NavigationService.NavigateAsync(new Uri(NavigationConstants.appAddress + "CultureSelectionPage"));
                }
                else
                {
                    await _localDataManagementService.VerifyLocalTablesUpdateFromExternalDataAsync();

                    if (await _localDataManagementService.HasCharactersCreatedAsync())
                        await NavigationService.NavigateAsync(new Uri(NavigationConstants.appAddress + "GameMasterPage/NavigationPage/GamePage"));
                    else if (!(await _localDataManagementService.HasCultureSelectedAsync()))
                        await NavigationService.NavigateAsync(new Uri(NavigationConstants.appAddress + "CultureSelectionPage"));
                    else
                        await NavigationService.NavigateAsync(new Uri(NavigationConstants.appAddress + "CharacterCreationPage"));

                }

                PageIsBusy = false;
            }
        }

        public override void Destroy()
        {
            _localDataManagementService.Dispose();
            base.Destroy();
        }
    }
}
