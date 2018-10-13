using Prism.Navigation;
using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.CharactersData;
using StoryTellerTemplate.Interfaces.Services.CharacterCreation;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Models.CharacterCreation;
using StoryTellerTemplate.ViewModels.Bases;

namespace StoryTellerTemplate.ViewModels
{
    public class CharacterCreationPageViewModel : BindableContentBaseViewModel, IGameContentManagerViewModelBinder
    {
        private ICharacterCreationAppService _characterCreationAppService;
        private ICharacterDataLocalRepository _characterDataLocalPersistentRepository;

        public CharacterCreationPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
        }

        CharacterCreationVm characterCreation;
        public CharacterCreationVm CharacterCreation
        {
            get => characterCreation;
            set => SetProperty(ref characterCreation, value);
        }
     
    }
}
