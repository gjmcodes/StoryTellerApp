using Prism.Navigation;
using StoryTellerTemplate.Interfaces.Services.GameContent;

namespace StoryTellerTemplate.ViewModels
{
    public class GameContentLoaderPageViewModel : ViewModelBase
	{
        private readonly IGameContentAppService _gameContentAppService;


        public GameContentLoaderPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
        }
    }
}
