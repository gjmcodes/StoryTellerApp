using StoryTeller.Core.Enums.Text;
using System.Collections.Generic;

namespace StoryTeller.Core.ContentTranslation
{
    public class FontAttributeTranslator
    {
        const string italicRegexPattern = @"(<atr-italic>[\s\S]+?<\/atr-italic>)";
        const string boldRegexPattern = @"(<atr-bold>[\s\S]+?<\/atr-bold>)";

        public const string attributeBoldStart = "<atr-bold>";
        public const string attributeBoldEnd = "</atr-bold>";

        public const string attributeItalicStart = "<atr-italic>";
        public const string attributeItalicEnd = "</atr-italic>";

        IList<ContentTranslationDto> BreakIntoAttribute(IEnumerable<ContentTranslationDto> paragraphedContents, FontAttribute attribute, string regexPattern, string attributeMarkStart, string attributeMarkEnd)
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

                    var dto = new ContentTranslationDto() { content = formattedItem, fontAttribute = hasAttribute ? attribute : FontAttribute.None };

                    newContents.Add(dto);
                }
            }

            return newContents;
        }

        IList<ContentTranslationDto> BreakBoldContent(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = BreakIntoAttribute(paragraphedContents, FontAttribute.Bold, boldRegexPattern, attributeBoldStart, attributeBoldEnd);

            return contents;
        }

        IList<ContentTranslationDto> BreakItalicContent(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = BreakIntoAttribute(paragraphedContents, FontAttribute.Italic, italicRegexPattern, attributeItalicStart, attributeItalicEnd);

            return contents;
        }

        public IEnumerable<ContentTranslationDto> BreakAttributes(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var newContents = BreakItalicContent(paragraphedContents);
            newContents = BreakBoldContent(newContents);

            return newContents;
        }
    }
}
