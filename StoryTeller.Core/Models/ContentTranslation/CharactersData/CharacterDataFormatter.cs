using StoryTeller.Core.Interfaces.Repositories.Local.CharactersData;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation.CharactersData
{
    public class CharacterDataFormatter : ContentFormatter
    {
        //ToDo: Injetar repository de character data
        ICharacterDataLocalRepository _characterDataLocalRepository;

        public CharacterDataFormatter()
        {
        }

        public async Task<string> GetCharacterDataAsync(string dataToGet)
        {
            // Realizer um Select do repository de characterData baseado no parâmetro
            var value = await _characterDataLocalRepository.GetCharacterDataColumnValueAsync(dataToGet);

            return "C_DATA";
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
