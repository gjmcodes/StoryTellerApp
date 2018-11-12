using Prism.Navigation;
using StoryTeller.Xamarin.Domain.Entities.App.Repositories;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Models.GameContent;
using StoryTellerTemplate.ViewModels.Bases;
using System.Threading.Tasks;

namespace StoryTellerTemplate.ViewModels
{
    public class GamePageViewModel : BindableContentBaseViewModel, IGameContentManagerViewModelBinder
    {
        private readonly IGameContentAppService _gameContentAppService;

        public GamePageViewModel(INavigationService navigationService,
            IAppDictionaryLocalRepository appDictionaryLocalRepository,
            IGameContentAppService gameContentAppService)
            : base(navigationService, appDictionaryLocalRepository)
        {
            _gameContentAppService = gameContentAppService;
        }


        protected override async Task ExecuteActionAsync(GameActionVm action)
        {
            var page = await _gameContentAppService.GetPageByIdAsync(action.PageIdToFetch);

            BindContentData(page);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            await LoadDataAsync();
        }

        async Task LoadDataAsync()
        {
            var pageVm = await _gameContentAppService.GetCurrentPageAsync();

            BindContentData(pageVm);
        }

    }
}
