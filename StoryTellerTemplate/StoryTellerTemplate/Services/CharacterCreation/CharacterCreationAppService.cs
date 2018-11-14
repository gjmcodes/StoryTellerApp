using StoryTeller.Core.Interfaces.Repositories.Users;
using StoryTeller.Xamarin.Domain.Entities.App;
using StoryTeller.Xamarin.Domain.Entities.CharactersData.Repositories;
using StoryTeller.Xamarin.Domain.Entities.Pages.Repositories;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Interfaces.Services.CharacterCreation;
using StoryTellerTemplate.Models.CharacterCreation;
using StoryTellerTemplate.Models.MainPage;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Services.CharacterCreation
{
    public class CharacterCreationAppService : BaseAppService, ICharacterCreationAppService
    {
        private readonly IPageLocalRepository _pageLocalRepository;
        private readonly ICharacterLocalRepository _characterLocalRepository;
        private readonly ICharacterCreationVmFactory _characterCreationVmFactory;
        private readonly IPageVmFactory _pageVmFactory;
        private readonly IUserCharacterRepository _userCharacterRepository;

        public CharacterCreationAppService(
            IPageLocalRepository pageLocalRepository,
            ICharacterLocalRepository characterLocalRepository,
            ICharacterCreationVmFactory characterCreationVmFactory,
            IPageVmFactory pageVmFactory,
            IUserCharacterRepository userCharacterRepository)
        {
            _pageLocalRepository = pageLocalRepository;
            _characterLocalRepository = characterLocalRepository;
            _characterCreationVmFactory = characterCreationVmFactory;
            _pageVmFactory = pageVmFactory;
            _userCharacterRepository = userCharacterRepository;
        }

        public async Task<bool> CreateCharacterAsync(CharacterCreationVm characterCreationVm)
        {
            var character = await _characterCreationVmFactory.MapVmToCharacterAsync(characterCreationVm);
            var persistence = await _characterLocalRepository.AddAsync(character);

            var xamUserData = new XamarinUserCharacterData(string.Empty, character.CharacterId, string.Empty);
            await _userCharacterRepository.AddAsync(xamUserData);

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
