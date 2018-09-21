using Prism.Commands;
using Prism.Navigation;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Interfaces.Services.RoomActions;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.Models.GameContent;
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

            _gameContentAppService = gameContentAppService;
            _roomActionAppService = roomActionAppService;

            Actions = new ObservableCollection<GameActionVm>();
            ExecuteActionCommand = new DelegateCommand<GameActionVm>(async (action) => await ExecuteAction(action));
        }

        public ObservableCollection<GameActionVm> Actions { get; }

        public DelegateCommand NextPageCommand { get; }
        public DelegateCommand<GameActionVm> ExecuteActionCommand { get; }

        async Task ExecuteAction(GameActionVm action)
        {
            var t = action;
            await Task.Delay(1000);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            await LoadDataAsync();
        }

        async Task LoadDataAsync()
        {
            var roomVm = await _gameContentAppService.GetCurrentRoomDataAsync();

            _gameContentManager.BindContentText(roomVm.Content);

            Actions.Clear();

            foreach (var item in roomVm.Actions)
            {
                Actions.Add(item);
            }
        }

        public void BindCustomTextBindingPage(IGameContentManager manager)
        {
            _gameContentManager = manager;
        }
    }
}
