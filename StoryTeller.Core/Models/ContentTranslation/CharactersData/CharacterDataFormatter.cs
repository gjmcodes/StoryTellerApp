using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation.CharactersData
{
    public class CharacterDataFormatter : ContentFormatter
    {
        //ToDo: Injetar repository de character data
        //ICharacterDataLocalRepository _characterDataLocalRepository;

        public CharacterDataFormatter()
        {
        }

        public async Task<string> GetCharacterDataAsync(string dataToGet)
        {
            // Realizer um Select do repository de characterData baseado no parâmetro

            return "C_DATA";
        }
        public override async Task<string> GetFormattedContentAsync(string contentBetweenMarkers)
        {
            return await GetCharacterDataAsync(contentBetweenMarkers);
        }
    }
}
