using StoryTeller.Core.ContentTranslation.ContentBuilders;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation
{
    public struct ContentBuilder
    {
        readonly ContentBuilderParameters contentParameters;
        readonly ContentFormatter contentFormatter;

        public ContentBuilder(ContentFormatter contentFormatter)
        {
            this.contentFormatter = contentFormatter;
            contentParameters = new ContentBuilderParameters();
        }

        public ContentBuilder(ContentBuilderParameters contentParameters, ContentFormatter contentFormatter)
        {
            this.contentParameters = contentParameters;
            this.contentFormatter = contentFormatter;
        }

        async Task<ContentTranslationDto> BuildContentDtoAsync(ContentTranslationDto originalContent, string formattedItem, bool hasAttribute)
        {
            var dto = new ContentTranslationDto()
            {
                content = hasAttribute ? await contentFormatter.GetFormattedContentAsync(formattedItem) : formattedItem,
                amountLineBreaks = originalContent.amountLineBreaks,
                fontAttribute = hasAttribute ? contentParameters.fontAttributeOption : originalContent.fontAttribute,
                fontFamily = originalContent.fontFamily,
                fontSize = originalContent.fontSize,
                hexBackgroundColor = originalContent.hexBackgroundColor,
                hexForegroundColor = originalContent.hexForegroundColor,
                lineBreak = originalContent.lineBreak,
                paragraphId = originalContent.paragraphId
            };

            return dto;
        }


        public async Task<IEnumerable<ContentTranslationDto>> TranslateContentAsync(IEnumerable<ContentTranslationDto> breakingContents,
            string attributeMarkStart, string attributeMarkEnd, string regexPattern)
        {
            var newContents = new List<ContentTranslationDto>();

            foreach (var content in breakingContents)
            {
                var contents = RegexSplitter.Split(content.content, regexPattern);

                if (content.lineBreak)
                {
                    newContents.Add(content);
                    continue;
                }

                foreach (var item in contents)
                {
                    var hasAttribute = (item.Contains(attributeMarkStart) && item.Contains(attributeMarkEnd));

                    var formattedItem = item.Replace(attributeMarkStart, string.Empty).Replace(attributeMarkEnd, string.Empty);

                    var dto = await BuildContentDtoAsync(content, formattedItem, hasAttribute);

                    newContents.Add(dto);
                }
            }

            return newContents;
        }
    }
}
