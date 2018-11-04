using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Navigation;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.InternalData.Interfaces.Services;
using StoryTellerTemplate.Interfaces.Services.CultureSelection;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Models.ContentDownload;
using StoryTellerTemplate.Models.GameCultures;
using StoryTellerTemplate.ViewsParameters;
using Xamarin.Forms;

namespace StoryTellerTemplate.ViewModels
{
    public class CultureSelectionPageViewModel : ViewModelBase
    {
        private bool _isActiveForFirstTime;

        private readonly ICultureSelectionAppService _cultureSelectionAppService;
        private readonly IUserStatusLocalRepository _userStatusLocalPersistentRepository;
        private readonly ILocalDataManagerService _localDataManagerService;
        private readonly IGameContentDownloadAppService _gameContentDownloadAppService;

        public ObservableCollection<CultureVm> Cultures { get; }

        public CultureSelectionPageViewModel(INavigationService navigationService,
            ICultureSelectionAppService cultureSelectionAppService,
            IUserStatusLocalRepository userStatusLocalPersistentRepository,
            ILocalDataManagerService localDataManagerService,
            IGameContentDownloadAppService gameContentDownloadAppService) : base(navigationService)
        {
            _cultureSelectionAppService = cultureSelectionAppService;
            _userStatusLocalPersistentRepository = userStatusLocalPersistentRepository;
            _localDataManagerService = localDataManagerService;
            _gameContentDownloadAppService = gameContentDownloadAppService;

            DownloadProgress = new DownloadProgress();
            Cultures = new ObservableCollection<CultureVm>();
            SelectCultureCommand = new Command<CultureVm>(async (culture) => await SelectCultureAsync(culture));
            _isActiveForFirstTime = true;
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
            await NavigationService.NavigateAsync("GameMasterPage/NavigationPage/GamePage");
        }

        async Task NavigateToCharacterCreationPage()
        {
            await NavigationService.NavigateAsync("CharacterCreationPage");
        }

        public async Task SelectCultureAsync(CultureVm selectedCulture)
        {
            var persistedCulture = await _userStatusLocalPersistentRepository.SetSelectedCultureAsync(selectedCulture.CultureCode);

            if (persistedCulture)
            {
                DownloadProgress.ProgressBarIsVisible = true;
                PageIsBusy = true;

                await _localDataManagerService.ClearLocalDataForCulctureChangeAsync();
                var contentDownloadResult = await _gameContentDownloadAppService.DownloadGameContentForCultureAsync(DownloadProgress);

                if (_isActiveForFirstTime)
                    await NavigateToCharacterCreationPage(); //Chamar criação de personagem
                else
                    await NavigateToGameMasterPageAsync();

                await Task.Delay(5000);

                DownloadProgress.ProgressBarIsVisible = false;
                PageIsBusy = false;
            }

        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey(ParametersKeys.model))
            {
                var viewParams = (CultureSelectionParams)parameters[ParametersKeys.model];
                _isActiveForFirstTime = !viewParams.IsCalledAsMenuOption;
            }

            // ToDo: Deverá verificar se é necessário atualizar estrutura das tabelas
            // e/ou criar novas
            await _localDataManagerService.UpdateCreateLocalTablesAsync();

            var cultures = await _cultureSelectionAppService.GetCulturesAsync();

            Cultures.Clear();

            foreach (var item in cultures)
            {
                Cultures.Add(item);
            }
        }
    }
}
