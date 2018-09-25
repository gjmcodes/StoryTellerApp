using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using StoryTellerTemplate.Models.CharacterCreation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTellerTemplate.ViewModels
{
	public class CharacterCreationViewModel : ViewModelBase
	{

        public CharacterCreationViewModel(INavigationService navigationService) 
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
