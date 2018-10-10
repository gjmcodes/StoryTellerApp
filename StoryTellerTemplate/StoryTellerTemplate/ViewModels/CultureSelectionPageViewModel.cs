using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Navigation;
using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Users;
using StoryTellerTemplate.Interfaces.Services.CultureSelection;
using StoryTellerTemplate.Models.GameContent;
using Xamarin.Forms;

namespace StoryTellerTemplate.ViewModels
{
    public class CultureSelectionPageViewModel : ViewModelBase
    {

        private readonly ICultureSelectionAppService _cultureSelectionAppService;
        private readonly IUserStatusLocalPersistentRepository _userStatusLocalPersistentRepository;

        public ObservableCollection<string> Cultures { get; }

        public CultureSelectionPageViewModel(INavigationService navigationService,
            ICultureSelectionAppService cultureSelectionAppService) : base(navigationService)
        {
            _cultureSelectionAppService = cultureSelectionAppService;
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
            if (await _userStatusLocalPersistentRepository.HasSelectedCultureAsync())
            {
                //Navegar para próxima página
            }
            else
            {
                var cultures = await _cultureSelectionAppService.GetCulturesAsync();

                foreach (var item in cultures)
                {
                    Cultures.Add(item);
                }
            }
        }
    }
}
