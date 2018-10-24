using StoryTeller.Core.Interfaces.Repositories.Local.CharactersData;
using StoryTeller.Core.Interfaces.Repositories.Local.Pages;
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
        private readonly IPageLocalRepository _pageLocalRepository;
        private readonly ICharacterDataLocalRepository _characterDataLocalRepository;
        private readonly ICharacterCreationVmFactory _characterCreationVmFactory;
        private readonly IPageVmFactory _pageVmFactory;

        public CharacterCreationAppService(
            IPageLocalRepository pageLocalRepository,
            ICharacterDataLocalRepository characterDataLocalRepository,
            ICharacterCreationVmFactory characterCreationVmFactory,
            IPageVmFactory pageVmFactory)
        {
            _pageLocalRepository = pageLocalRepository;
            _characterDataLocalRepository = characterDataLocalRepository;
            _characterCreationVmFactory = characterCreationVmFactory;
            _pageVmFactory = pageVmFactory;
        }

        public async Task<bool> CreateCharacterAsync(CharacterCreationVm characterCreationVm)
        {
            var character = _characterCreationVmFactory.MapVmToCharacter(characterCreationVm);
            var persistence = await _characterDataLocalRepository.AddAsync(character);

            return persistence;
        }

        public async Task<PageVm> GetCharacterCreationPageAsync()
        {
            var creationTranslatedPage = await _pageLocalRepository.GetPageByIdAsync("char-creation");
            var creationPageVm = await _pageVmFactory.MapTranslatedPageDtoToPageVmAsync(creationTranslatedPage);

            return creationPageVm;
        }
    }
}
