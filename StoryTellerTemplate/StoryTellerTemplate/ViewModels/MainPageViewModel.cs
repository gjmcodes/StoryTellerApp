using Prism.Commands;
using Prism.Navigation;
using StoryTeller.Core.Services;
using StoryTellerTemplate.Interfaces.Services;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.Services.GameContent;
using StoryTellerTemplate.Services.Pages;
using System.Threading.Tasks;

namespace StoryTellerTemplate.ViewModels
{
    public class MainPageViewModel : ViewModelBase, ICustomTextBindingViewModel
    {
        private readonly IPaginationAppService _paginationAppService;
        private ICustomTextBindingPage _customTextBindingPage;
        private readonly GameContentAppService _gameContentAppService;

        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";

            NextPageCommand = new DelegateCommand(async() => await LoadDataAsync());
            _paginationAppService = new PaginationAppService();
            _gameContentAppService = new GameContentAppService();
        }

        public DelegateCommand NextPageCommand { get; }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            await LoadDataAsync();
        }

        async Task LoadDataAsync()
        {
            var gameContent = await _gameContentAppService.GetCurrentGameContextAsync(null, 0);

            _customTextBindingPage.BindContentText(gameContent.Room.Content);
        }

        public void BindCustomTextBindingPage(ICustomTextBindingPage page)
        {
            _customTextBindingPage = page;
        }
    }
}
