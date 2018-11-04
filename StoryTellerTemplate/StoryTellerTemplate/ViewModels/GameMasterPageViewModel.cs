using Prism.Commands;
using Prism.Navigation;
using StoryTellerTemplate.ViewsParameters;
using System.Threading.Tasks;

namespace StoryTellerTemplate.ViewModels
{
    public class GameMasterPageViewModel : ViewModelBase
    {
        public GameMasterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            SelectMenuOptionCommand = new DelegateCommand<string>(async (param) => await SelectMenuOption(param));
        }

        public DelegateCommand<string> SelectMenuOptionCommand { get; }

        public async Task SelectMenuOption(string option)
        {
            var navParams = new NavigationParameters();

            if (option == "CultureSelectionPage")
            {
                var cultureSelParams = new CultureSelectionParams() { IsCalledAsMenuOption = true };
                navParams.Add(ParametersKeys.model, cultureSelParams);
            }

            await NavigationService.NavigateAsync("GameMasterPage/NavigationPage/" + option, navParams);
        }

    }
}
