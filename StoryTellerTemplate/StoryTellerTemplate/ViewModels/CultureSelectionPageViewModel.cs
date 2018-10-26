using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Navigation;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.InternalData.Interfaces.Services;
using StoryTellerTemplate.Interfaces.Services.CultureSelection;
using StoryTellerTemplate.Models.GameCultures;
using Xamarin.Forms;

namespace StoryTellerTemplate.ViewModels
{
    public class CultureSelectionPageViewModel : ViewModelBase
    {

        private readonly ICultureSelectionAppService _cultureSelectionAppService;
        private readonly IUserStatusLocalRepository _userStatusLocalPersistentRepository;
        private readonly ILocalDataManagerService _localDataManagerService;

        public ObservableCollection<CultureVm> Cultures { get; }

        public CultureSelectionPageViewModel(INavigationService navigationService,
            ICultureSelectionAppService cultureSelectionAppService,
            IUserStatusLocalRepository userStatusLocalPersistentRepository,
            ILocalDataManagerService localDataManagerService) : base(navigationService)
        {
            _cultureSelectionAppService = cultureSelectionAppService;
            _userStatusLocalPersistentRepository = userStatusLocalPersistentRepository;
            _localDataManagerService = localDataManagerService;

            Cultures = new ObservableCollection<CultureVm>();
            SelectCultureCommand = new Command<CultureVm>(async (culture) => await SelectCultureAsync(culture));
        }

        public Command<CultureVm> SelectCultureCommand { get; }

        async Task NavigateToGameMasterPageAsync()
        {
            await NavigationService.NavigateAsync("GameMasterPage/NavigationPage/GamePage");
        }

        async Task NavigateToContentDownloadPageAsync()
        {
            await NavigationService.NavigateAsync("GameContentLoaderPage");
        }

        public async Task SelectCultureAsync(CultureVm selectedCulture)
        {
            if (await _userStatusLocalPersistentRepository.SetSelectedCultureAsync(selectedCulture.CultureCode))
            {
                await NavigateToGameMasterPageAsync();
            }


        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            // ToDo: Deverá verificar se é necessário atualizar estrutura das tabelas
            // e/ou criar novas
            await _localDataManagerService.UpdateCreateLocalTablesAsync();

            if (await _userStatusLocalPersistentRepository.HasSelectedCultureAsync())
            {
                await NavigateToGameMasterPageAsync();
            }
            else
            {
                var cultures = await _cultureSelectionAppService.GetCulturesAsync();

                Cultures.Clear();

                foreach (var item in cultures)
                {
                    Cultures.Add(item);
                }
            }
        }
    }
}
