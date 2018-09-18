using Prism.Commands;
using Prism.Navigation;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Interfaces.Services.RoomActions;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Interfaces.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace StoryTellerTemplate.ViewModels
{
    
    public class MainPageViewModel : ViewModelBase, IGameContentManagerViewModelBinder
    {
        private readonly IRoomActionAppService _roomActionAppService;
        private readonly IGameContentAppService _gameContentAppService;
        IGameContentManager _gameContentManager;

        public MainPageViewModel(INavigationService navigationService,
            IGameContentAppService gameContentAppService,
            IRoomActionAppService roomActionAppService) 
            : base (navigationService)
        {
            Title = "Main Page";

            NextPageCommand = new DelegateCommand(async() => await LoadDataAsync());
            _gameContentAppService = gameContentAppService;
            _roomActionAppService = roomActionAppService;
        }

        public DelegateCommand NextPageCommand { get; }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            await LoadDataAsync();
        }

        async Task LoadDataAsync()
        {
            var roomVm = await _gameContentAppService.GetCurrentRoomDataAsync();

            _gameContentManager.BindContentText(roomVm.Content);

            await Task.Delay(5000);

        }

        public void BindCustomTextBindingPage(IGameContentManager manager)
        {
            _gameContentManager = manager;
        }
    }
}
