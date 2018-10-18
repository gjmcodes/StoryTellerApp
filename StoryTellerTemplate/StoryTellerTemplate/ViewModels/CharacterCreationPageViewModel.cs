using Prism.Navigation;
using StoryTeller.Core.Interfaces.Repositories.Local.CharactersData;
using StoryTellerTemplate.Interfaces.Services.CharacterCreation;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.Models.CharacterCreation;
using StoryTellerTemplate.ViewModels.Bases;

namespace StoryTellerTemplate.ViewModels
{
    public class CharacterCreationPageViewModel : BindableContentBaseViewModel, IGameContentManagerViewModelBinder
    {
        private ICharacterCreationAppService _characterCreationAppService;
        private ICharacterDataLocalRepository _characterDataLocalPersistentRepository;

        public CharacterCreationPageViewModel(INavigationService navigationService,
            ICharacterCreationAppService characterCreationAppService,
            ICharacterDataLocalRepository characterDataLocalPersistentRepository) 
            : base(navigationService)
        {
            _characterCreationAppService = characterCreationAppService;
            _characterDataLocalPersistentRepository = characterDataLocalPersistentRepository;
        }


        CharacterCreationVm characterCreation;
        public CharacterCreationVm CharacterCreation
        {
            get => characterCreation;
            set => SetProperty(ref characterCreation, value);
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            var content = await _characterCreationAppService.GetCharacterCreationPageAsync();

            BindContentData(content);

            base.OnNavigatingTo(parameters);
        }
    }
}
