using Prism.Commands;
using Prism.Navigation;
using StoryTeller.Xamarin.Domain.Entities.App.Repositories;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.ViewModels.Bases;
using StoryTellerTemplate.ViewsParameters;
using System.Threading.Tasks;

namespace StoryTellerTemplate.ViewModels
{
    public class GameMasterPageViewModel : BindableContentBaseViewModel, IAppDictionaryViewModel
    {
        public GameMasterPageViewModel(INavigationService navigationService,
            IAppDictionaryLocalRepository appDictionaryLocalRepository) : base(navigationService, appDictionaryLocalRepository)
        {
            SelectMenuOptionCommand = new DelegateCommand<string>(async (param) => await SelectMenuOption(param));
        }


        public DelegateCommand<string> SelectMenuOptionCommand { get; }


        public async Task SelectMenuOption(string option)
        {
            var navParams = new NavigationParameters();

            if (option == "Exit")
                App.Current.Quit();
            else
            {

                switch (option)
                {
                    case "CultureSelectionPage":
                        var cultureSelParams = new CultureSelectionParams() { IsCalledAsMenuOption = true };
                        navParams.Add(ParametersKeys.model, cultureSelParams);
                        break;

                    default:
                        break;
                }

                await NavigationService.NavigateAsync("GameMasterPage/NavigationPage/" + option, navParams);
            }

        }

        public void BindDictionaryConsumer(IAppDictionaryConsumer appDictionaryConsumer)
        {
            _appDictionaryConsumer = appDictionaryConsumer;
        }
    }
}
