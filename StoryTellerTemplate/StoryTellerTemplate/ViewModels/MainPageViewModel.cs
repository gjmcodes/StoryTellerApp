using Prism.Commands;
using Prism.Navigation;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Interfaces.Views;
using System.Threading.Tasks;

namespace StoryTellerTemplate.ViewModels
{
    public class MainPageViewModel : ViewModelBase, ICustomTextBindingViewModel
    {
        private readonly IGameContentAppService _gameContentAppService;
        private ICustomTextBindingPage _customTextBindingPage;

        public MainPageViewModel(INavigationService navigationService, IGameContentAppService gameContentAppService) 
            : base (navigationService)
        {
            Title = "Main Page";

            NextPageCommand = new DelegateCommand(async() => await LoadDataAsync());
            _gameContentAppService = gameContentAppService;
        }

        public DelegateCommand NextPageCommand { get; }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            await LoadDataAsync();
        }

        async Task LoadDataAsync()
        {
            var roomVm = await _gameContentAppService.GetCurrentRoomDataAsync();

            _customTextBindingPage.BindContentText(roomVm.Content);
        }

        public void BindCustomTextBindingPage(ICustomTextBindingPage page)
        {
            _customTextBindingPage = page;
        }
    }
}
