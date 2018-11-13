using Prism.Navigation;
using StoryTeller.Core.Services.GameContentDownload;
using StoryTeller.Xamarin.Domain.Interfaces.Services.LocalData;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Models.ContentDownload;
using StoryTellerTemplate.Navigations;
using System;

namespace StoryTellerTemplate.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {

        private readonly ILocalDataManagementService _localDataManagementService;

        public StartPageViewModel(INavigationService navigationService,
            ILocalDataManagementService localDataManagementService,
            IGameContentDownloadAppService gameContentDownloadAppService)
            : base(navigationService)
        {
            DownloadProgress = new DownloadProgress();

            _localDataManagementService = localDataManagementService;
        }

        public DownloadProgress DownloadProgress { get; }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            PageIsBusy = true;

            var hasLocalTables = await _localDataManagementService.HasLocalTablesAsync();

            if (!hasLocalTables)
            {
                await _localDataManagementService.CreateLocalTablesAsync();

                await NavigationService.NavigateAsync("CultureSelectionPage");
            }
            else
            {
                //await _localDataManagementService.VerifyLocalTablesUpdateFromExternalDataAsync();

                //Verificar se há dados existentes (Personagem criado, cultura selecionada, etc)
                if (await _localDataManagementService.HasCharactersCreatedAsync())
                    await NavigationService.NavigateAsync(new Uri(NavigationConstants.appAddress + "GameMasterPage/NavigationPage/GamePage"));
            }

            PageIsBusy = false;
        }
    }
}
