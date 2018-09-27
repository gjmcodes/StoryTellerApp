using StoryTeller.Core.Enums.Text;
using System.Collections.Generic;

namespace StoryTeller.Core.ContentTranslation
{
    public struct CharacterDataTranslator
    {
        const string characterNameRegexPattern = @"(<c-data_name>[\s\S]+?<\/c-data_name>)";
        const string characterNameStart = "<c-data_name>";
        const string characterNameEnd = "</c-data_name>";

        ContentBuilder contentBuilder;

        IList<ContentTranslationDto> BreakIntoData(IEnumerable<ContentTranslationDto> paragraphedContents,
            string regexPattern, string attributeMarkStart, string attributeMarkEnd, string dataToFill)
        {

            var regexSplitter = new RegexSplitter();

            var newContents = new List<ContentTranslationDto>();

            foreach (var content in paragraphedContents)
            {
                var contents = regexSplitter.Split(content.content, regexPattern);

                if (content.lineBreak)
                    newContents.Add(content);

                foreach (var item in contents)
                {
                    var hasAttribute = (item.Contains(attributeMarkStart) && item.Contains(attributeMarkEnd));
                    var formattedItem = item.Replace(attributeMarkStart, string.Empty).Replace(attributeMarkEnd, string.Empty);

                    if (hasAttribute)
                        formattedItem = dataToFill;

                    var dto = new ContentTranslationDto() { content = formattedItem };

                    newContents.Add(dto);
                }
            }

            return newContents;
        }

        IList<ContentTranslationDto> BreakCharacterName(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var characterName = "John";

            var contents = BreakIntoData(paragraphedContents, characterNameRegexPattern, characterNameStart, characterNameEnd, characterName);

            return contents;
        }

        public IEnumerable<ContentTranslationDto> BreakCharacterData(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            contentBuilder = new ContentBuilder();

            var contents = BreakCharacterName(paragraphedContents);

            return contents;
        }
    }
}
