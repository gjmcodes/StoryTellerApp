using StoryTeller.Core.ContentTranslation.ContentBuilders;
using StoryTeller.Core.ContentTranslation.FontAttributes;
using StoryTeller.Core.Enums.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation
{
    public class FontAttributeTranslator
    {
        FontAttributeContentFormatter fontAttributeContentFormatter;

        const string italicRegexPattern = @"(<atr-italic>[\s\S]+?<\/atr-italic>)";
        const string boldRegexPattern = @"(<atr-bold>[\s\S]+?<\/atr-bold>)";

        public const string attributeBoldStart = "<atr-bold>";
        public const string attributeBoldEnd = "</atr-bold>";

        public const string attributeItalicStart = "<atr-italic>";
        public const string attributeItalicEnd = "</atr-italic>";

        async Task<IList<ContentTranslationDto>> BreakIntoAttributeAsync(IEnumerable<ContentTranslationDto> paragraphedContents, FontAttribute attribute, string regexPattern, string attributeMarkStart, string attributeMarkEnd)
        {
            var contentBuilderParams = new ContentBuilderParameters(attribute);
            fontAttributeContentFormatter = new FontAttributeContentFormatter();
            var contentBuilder = new ContentBuilder(contentBuilderParams, fontAttributeContentFormatter);
            var newContents = await contentBuilder.TranslateContentAsync(paragraphedContents, attributeMarkStart, attributeMarkEnd, regexPattern);


            return newContents.ToList();
        }

        async Task<IList<ContentTranslationDto>> BreakBoldContentAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = await BreakIntoAttributeAsync(paragraphedContents, FontAttribute.Bold, boldRegexPattern, attributeBoldStart, attributeBoldEnd);

            return contents;
        }

        async Task<IList<ContentTranslationDto>> BreakItalicContentAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = await BreakIntoAttributeAsync(paragraphedContents, FontAttribute.Italic, italicRegexPattern, attributeItalicStart, attributeItalicEnd);

            return contents;
        }

        public async Task<IEnumerable<ContentTranslationDto>> BreakAttributesAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var newContents = await BreakItalicContentAsync(paragraphedContents);
            newContents = await BreakBoldContentAsync(newContents);

            return newContents;
        }
    }
}
