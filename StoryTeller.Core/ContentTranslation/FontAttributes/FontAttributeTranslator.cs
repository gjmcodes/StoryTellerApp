using StoryTeller.Core.ContentTranslation.FontAttributes;
using StoryTeller.Core.Enums.Text;
using System.Collections.Generic;
using System.Linq;

namespace StoryTeller.Core.ContentTranslation
{
    public class FontAttributeTranslator
    {
        readonly ContentBuilder contentBuilder;
        FontAttributeContentFormatter fontAttributeContentFormatter;

        const string italicRegexPattern = @"(<atr-italic>[\s\S]+?<\/atr-italic>)";
        const string boldRegexPattern = @"(<atr-bold>[\s\S]+?<\/atr-bold>)";

        public const string attributeBoldStart = "<atr-bold>";
        public const string attributeBoldEnd = "</atr-bold>";

        public const string attributeItalicStart = "<atr-italic>";
        public const string attributeItalicEnd = "</atr-italic>";

        IList<ContentTranslationDto> BreakIntoAttribute(IEnumerable<ContentTranslationDto> paragraphedContents, FontAttribute attribute, string regexPattern, string attributeMarkStart, string attributeMarkEnd)
        {
            fontAttributeContentFormatter = new FontAttributeContentFormatter();

            var newContents = contentBuilder.TranslateContentWithDataToFill(paragraphedContents, attributeMarkStart, attributeMarkEnd, regexPattern, fontAttributeContentFormatter);

            
            return newContents.ToList();
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
