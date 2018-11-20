using StoryTeller.Core.ContentTranslation.CharactersData;
using StoryTeller.Core.Enums.Text;
using StoryTeller.Core.Interfaces.Repositories.CharactersData;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation
{
    public class CharacterDataTranslatorService : BaseService, ICharacterDataTranslatorService
    {
        const string characterDataRegexPattern = @"(<cdata>[\s\S]+?<\/cdata>)";
        const string characterDataStart = "<cdata>";
        const string characterDataEnd = "</cdata>";

        private readonly CharacterDataFormatter _characterDataFormatter;
        private readonly ICharacterDataRepository _characterDataRepository;

        public CharacterDataTranslatorService(CharacterDataFormatter characterDataFormatter,
            ICharacterDataRepository characterDataRepository)
        {
            _characterDataFormatter = characterDataFormatter;
            _characterDataRepository = characterDataRepository;
        }

        async Task<IList<ContentTranslationDto>> BreakIntoDataAsync(IEnumerable<ContentTranslationDto> paragraphedContents,
            string regexPattern, string attributeMarkStart, string attributeMarkEnd, string dataToFill)
        {
            var contentBuilder = new ContentBuilder(_characterDataFormatter);
            var contents = await contentBuilder.TranslateContentAsync(paragraphedContents, attributeMarkStart, attributeMarkEnd, regexPattern);

            return contents.ToList();
        }

        async Task<IList<ContentTranslationDto>> BreakCharacterNameAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var characterName = "John";

            var contents = await BreakIntoDataAsync(paragraphedContents, characterDataRegexPattern, characterDataStart, characterDataEnd, characterName);

            return contents;
        }

        public async Task<IEnumerable<ContentTranslationDto>> BreakCharacterDataAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = await BreakCharacterNameAsync(paragraphedContents);

            return contents;
        }

        public bool HasCharacterDataMarkers(string content)
        {
            return content.Contains(characterDataStart);
        }

        public async Task<string> TranslateCharacterDataAsync(string content)
        {
            var contents = RegexSplitter.Split(content, characterDataRegexPattern, characterDataStart, characterDataEnd);

            var sb = new StringBuilder();

            foreach (var item in contents)
            {
                if (string.IsNullOrEmpty(item))
                    continue;

                var translated = await _characterDataRepository.GetCharacterDataByColumnAsync(item);

                sb.Append(translated);
            }

            return sb.ToString();
        }
    }
}
