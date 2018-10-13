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
            SelectCultureCommand = new Command<string>(async (culture) => await SelectCultureAsync(culture));
        }

        public Command<string> SelectCultureCommand { get; }

        public async Task SelectCultureAsync(string selectedCulture)
        {
            await _userStatusLocalPersistentRepository.SetSelectedCultureAsync(selectedCulture);

            //Navegar para próxima página
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            await _localDataManagerService.CreateLocalTablesAsync();

            //if (await _userStatusLocalPersistentRepository.HasSelectedCultureAsync())
            //{
            //    //Navegar para próxima página
            //}
            //else
            //{
                var cultures = await _cultureSelectionAppService.GetCulturesAsync();

                Cultures.Clear();

                foreach (var item in cultures)
                {
                    Cultures.Add(item);
                }
            //}
        }
    }
}
