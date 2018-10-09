﻿using Prism.Commands;
using Prism.Navigation;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.Models.GameContent;
using StoryTellerTemplate.Models.MainPage;
using StoryTellerTemplate.ViewModels.Bases;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTellerTemplate.ViewModels
{

    public class MainPageViewModel : BindableContentBaseViewModel, IGameContentManagerViewModelBinder
    {
        private readonly IGameContentAppService _gameContentAppService;
        

        public MainPageViewModel(INavigationService navigationService,
            IGameContentAppService gameContentAppService)
            : base(navigationService)
        {
            Title = "Main Page";

            _gameContentAppService = gameContentAppService;

            Actions = new ObservableCollection<GameActionVm>();
            ExecuteActionCommand = new Command<GameActionVm>(async (action) => await ExecuteAction(action));
        }

        public ObservableCollection<GameActionVm> Actions { get; }

        public DelegateCommand NextPageCommand { get; }
        public Command<GameActionVm> ExecuteActionCommand { get; }

        async Task ExecuteAction(GameActionVm action)
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
