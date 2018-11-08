using Prism.Navigation;
using StoryTeller.Core.Interfaces.Repositories.Local.App;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.Models.GameContent;
using StoryTellerTemplate.Models.MainPage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTellerTemplate.ViewModels.Bases
{
    public class BindableContentBaseViewModel : ViewModelBase, IGameContentManagerViewModelBinder
    {
        public ObservableCollection<GameActionVm> Actions { get; }
        protected IAppDictionaryConsumer _appDictionaryConsumer;
        protected IGameContentManager _gameContentManager;

        protected readonly IAppDictionaryLocalRepository _appDictionaryLocalRepository;

        public BindableContentBaseViewModel(INavigationService navigationService,
            IAppDictionaryLocalRepository appDictionaryLocalRepository)
            : base(navigationService)
        {
            Actions = new ObservableCollection<GameActionVm>();
            _appDictionaryLocalRepository = appDictionaryLocalRepository;
            ExecuteActionCommand = new Command<GameActionVm>(async (action) => await ExecuteActionAsync(action));
        }

        public Command<GameActionVm> ExecuteActionCommand { get; }

        protected virtual async Task ExecuteActionAsync(GameActionVm action)
        {
            await Task.Delay(1000);
        }

        protected void BindContentData(PageVm pageVm)
        {
            _gameContentManager.BindImage(pageVm.Image);
            _gameContentManager.BindTitle(pageVm.Title);

            _gameContentManager.BindContentText(pageVm.Content);

            Actions.Clear();

            foreach (var item in pageVm.Actions)
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
