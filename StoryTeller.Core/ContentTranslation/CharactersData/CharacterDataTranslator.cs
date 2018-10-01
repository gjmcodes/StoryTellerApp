using StoryTeller.Core.Enums.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation
{
    public struct CharacterDataTranslator
    {
        const string characterNameRegexPattern = @"(<c-data_name>[\s\S]+?<\/c-data_name>)";
        const string characterNameStart = "<c-data_name>";
        const string characterNameEnd = "</c-data_name>";

        ContentBuilder contentBuilder;

        async Task<IList<ContentTranslationDto>> BreakIntoDataAsync(IEnumerable<ContentTranslationDto> paragraphedContents,
            string regexPattern, string attributeMarkStart, string attributeMarkEnd, string dataToFill)
        {

            //_nameCallContentFormatter = new NameCallContentFormatter(pronoums, false);
            //var contentBuilder = new ContentBuilder(_nameCallContentFormatter);
            //var contents = await contentBuilder.TranslateContentAsync(paragraphedContents, attributeMarkStart, attributeMarkEnd, regexPattern);

            //return contents.ToList();

            return null;
        }

        async Task<IList<ContentTranslationDto>> BreakCharacterNameAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var characterName = "John";

            var contents = await BreakIntoDataAsync(paragraphedContents, characterNameRegexPattern, characterNameStart, characterNameEnd, characterName);

            return contents;
        }

        public async Task<IEnumerable<ContentTranslationDto>> BreakCharacterDataAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            contentBuilder = new ContentBuilder();

            var contents = await BreakCharacterNameAsync(paragraphedContents);

            return contents;
        }
    }
}
