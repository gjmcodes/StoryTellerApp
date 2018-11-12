using System.Threading.Tasks;
using Prism.Navigation;
using StoryTeller.Xamarin.Domain.Entities.App.Repositories;
using StoryTellerTemplate.Interfaces.Services.CharacterCreation;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.Models.CharacterCreation;
using StoryTellerTemplate.Models.GameContent;
using StoryTellerTemplate.ViewModels.Bases;

namespace StoryTellerTemplate.ViewModels
{
    public class CharacterCreationPageViewModel : BindableContentBaseViewModel, IGameContentManagerViewModelBinder
    {
        private ICharacterCreationAppService _characterCreationAppService;

        public CharacterCreationPageViewModel(INavigationService navigationService,
            IAppDictionaryLocalRepository appDictionaryLocalRepository,
            ICharacterCreationAppService characterCreationAppService)
            : base(navigationService, appDictionaryLocalRepository)
        {
            _characterCreationAppService = characterCreationAppService;
            CharacterCreation = new CharacterCreationVm();
        }


        CharacterCreationVm characterCreation;
        public CharacterCreationVm CharacterCreation
        {
            get => characterCreation;
            set => SetProperty(ref characterCreation, value);
        }

        async Task NavigateToGameMasterPageAsync()
        {
            await NavigationService.NavigateAsync("GameMasterPage/NavigationPage/GamePage");
        }

        protected override async Task ExecuteActionAsync(GameActionVm action)
        {
            await _characterCreationAppService.CreateCharacterAsync(CharacterCreation);

            await NavigateToGameMasterPageAsync();
        }

        public void BindDictionaryConsumer(IAppDictionaryConsumer appDictionaryConsumer)
        {
            _appDictionaryConsumer = appDictionaryConsumer;
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            var dictionaryData = await _appDictionaryLocalRepository.GetAppDictionaryAsync();
            _appDictionaryConsumer.BindDictionaryData(dictionaryData);

            var content = await _characterCreationAppService.GetCharacterCreationPageAsync();

            BindContentData(content);

            base.OnNavigatingTo(parameters);
        }
    }
}
