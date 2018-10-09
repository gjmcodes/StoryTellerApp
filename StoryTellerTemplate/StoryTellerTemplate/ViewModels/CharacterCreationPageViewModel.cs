using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.CharactersData;
using StoryTellerTemplate.Interfaces.Services.CharacterCreation;
using StoryTellerTemplate.Interfaces.ViewModels;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.Models.CharacterCreation;
using StoryTellerTemplate.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTellerTemplate.ViewModels
{
	public class CharacterCreationPageViewModel : BindableContentBaseViewModel, IGameContentManagerViewModelBinder
    {
        private ICharacterCreationAppService _characterCreationAppService;
        private ICharacterDataLocalPersistentRepository _characterDataLocalPersistentRepository;

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
