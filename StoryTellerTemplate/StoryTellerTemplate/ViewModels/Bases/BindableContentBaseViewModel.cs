using Prism.Navigation;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.Models.GameContent;
using StoryTellerTemplate.Models.MainPage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StoryTellerTemplate.ViewModels.Bases
{
    public class BindableContentBaseViewModel : ViewModelBase, IGameContentManagerViewModelBinder
    {
        public ObservableCollection<GameActionVm> Actions { get; }
        protected IGameContentManager _gameContentManager;

        public BindableContentBaseViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            Actions = new ObservableCollection<GameActionVm>();
        }


        protected void BindContentData(PageVm pageVm)
        {
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
