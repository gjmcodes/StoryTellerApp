using StoryTeller.Core.Interfaces.Repositories.Local.CharactersData;
using StoryTeller.InternalData.Interfaces.Factories.CharactersData;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Interfaces.Services.CharacterCreation;
using StoryTellerTemplate.Models.CharacterCreation;
using StoryTellerTemplate.Models.GameContent;
using StoryTellerTemplate.Models.MainPage;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTellerTemplate.Services.CharacterCreation
{
    public class CharacterCreationAppService : BaseAppService, ICharacterCreationAppService
    {

        private readonly ICharacterDataLocalRepository _characterDataLocalRepository;
        private readonly ICharacterCreationVmFactory _characterCreationVmFactory;

        public CharacterCreationAppService(ICharacterDataLocalRepository characterDataLocalRepository,
            ICharacterCreationVmFactory characterCreationVmFactory)
        {
            _characterDataLocalRepository = characterDataLocalRepository;
            _characterCreationVmFactory = characterCreationVmFactory;
        }

        public async Task<bool> CreateCharacterAsync(CharacterCreationVm characterCreationVm)
        {
            var character = _characterCreationVmFactory.MapVmToCharacter(characterCreationVm);
            var persistence = await _characterDataLocalRepository.AddAsync(character);

            return persistence;
        }

        public async Task<PageVm> GetCharacterCreationPageAsync()
        {
            var pagemock = new PageVm()
            {
                Actions = new List<GameActionVm>()
                {
                   new GameActionVm(){Description= "Ok", PageIdToFetch= "page-1" }
                },
                Content = new List<Span>()
                {
                    new Span(){ Text = "Você é um oficial de polícia novato. Seu nome é "}
                }
            };

            return pagemock;
        }
    }
}
