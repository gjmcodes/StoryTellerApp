using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.ContentTranslation.ContentBuilders;
using StoryTeller.Core.ContentTranslation.FontAttributes;
using StoryTeller.Core.Enums.Text;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.ContentTranslation
{
    public class FontAttributeTranslatorService : BaseService, IFontAttributeTranslatorService
    {
        FontAttributeContentFormatter fontAttributeContentFormatter;

        const string italicRegexPattern = @"(<i>[\s\S]+?<\/i>)";
        const string boldRegexPattern = @"(<b>[\s\S]+?<\/b>)";

        public const string attributeBoldStart = "<b>";
        public const string attributeBoldEnd = "</b>";

        public const string attributeItalicStart = "<i>";
        public const string attributeItalicEnd = "</i>";

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
