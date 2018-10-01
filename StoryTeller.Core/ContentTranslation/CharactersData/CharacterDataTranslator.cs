using StoryTeller.Core.ContentTranslation.CharactersData;
using StoryTeller.Core.Enums.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation
{
    public class CharacterDataTranslator
    {
        const string characterNameRegexPattern = @"(<cdata>[\s\S]+?<\/cdata>)";
        const string characterNameStart = "<cdata>";
        const string characterNameEnd = "</cdata>";

        ContentBuilder contentBuilder;
        CharacterDataFormatter _characterDataFormatter;

        async Task<IList<ContentTranslationDto>> BreakIntoDataAsync(IEnumerable<ContentTranslationDto> paragraphedContents,
            string regexPattern, string attributeMarkStart, string attributeMarkEnd, string dataToFill)
        {

            _characterDataFormatter = new CharacterDataFormatter();
            var contentBuilder = new ContentBuilder(_characterDataFormatter);
            var contents = await contentBuilder.TranslateContentAsync(paragraphedContents, attributeMarkStart, attributeMarkEnd, regexPattern);

            return contents.ToList();
        }

        async Task<IList<ContentTranslationDto>> BreakCharacterNameAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var characterName = "John";

            var contents = await BreakIntoDataAsync(paragraphedContents, characterNameRegexPattern, characterNameStart, characterNameEnd, characterName);

            return contents;
        }

        public async Task<IEnumerable<ContentTranslationDto>> BreakCharacterDataAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = await BreakCharacterNameAsync(paragraphedContents);

            return contents;
        }
    }
}
