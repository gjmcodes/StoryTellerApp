using System.Collections;
using System.Collections.Generic;

namespace StoryTeller.Core.ContentTranslation
{
    public struct ContentBuilder
    {
        RegexSplitter regexSplitter;
        RegexSplitter RegexSplitter
        {
            get
            {
                regexSplitter = regexSplitter ?? new RegexSplitter();

                return regexSplitter;
            }
        }

        ContentTranslationDto BuildContentDto(ContentTranslationDto originalContent, string formattedItem)
        {
            var dto = new ContentTranslationDto()
            {
                content = formattedItem,
                amountLineBreaks = originalContent.amountLineBreaks,
                fontAttribute = originalContent.fontAttribute,
                fontFamily = originalContent.fontFamily,
                fontSize = originalContent.fontSize,
                hexBackgroundColor = originalContent.hexBackgroundColor,
                hexForegroundColor = originalContent.hexForegroundColor,
                lineBreak = originalContent.lineBreak,
                paragraphId = originalContent.paragraphId
            };

            return dto;
        }


        public IEnumerable<ContentTranslationDto> TranslateContentWithDataToFill(IEnumerable<ContentTranslationDto> breakingContents,
            string attributeMarkStart, string attributeMarkEnd,
            string regexPattern, ContentFormatter contentFormatter)
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

                    if (hasAttribute)
                        formattedItem = contentFormatter.GetFormattedContent(formattedItem);

                    var dto = BuildContentDto(content, formattedItem);

                    newContents.Add(dto);
                }
            }

            return newContents;
        }
    }
}
