using StoryTeller.Core.Interfaces.Repositories.CharactersData;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation.CharactersData
{
    public class CharacterDataFormatter : ContentFormatter
    {
        //ToDo: Injetar repository de character data
        private readonly ICharacterDataRepository _characterDataRepository;

        public CharacterDataFormatter(ICharacterDataRepository characterDataRepository)
        {
            _characterDataRepository = characterDataRepository;
        }

        public async Task<string> GetCharacterDataAsync(string dataToGet)
        {
            // Realizer um Select do repository de characterData baseado no parâmetro
            var value = await _characterDataRepository.GetCharacterDataByColumnAsync(dataToGet);

            return value;
        }
        public override async Task<string> GetFormattedContentAsync(string contentBetweenMarkers)
        {
            return await GetCharacterDataAsync(contentBetweenMarkers);
        }

        protected override void ReleaseResources()
        {
        }
    }
}
