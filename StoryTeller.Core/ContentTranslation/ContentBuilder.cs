namespace StoryTeller.Core.ContentTranslation
{
    public struct ContentBuilder
    {
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
        public ContentTranslationDto TranslateContentWithDataToFill(ContentTranslationDto originalContent, string attributeMarkStart, string attributeMarkEnd, string item, ContentFormatter contentFormatter)
        {
            var hasAttribute = (item.Contains(attributeMarkStart) && item.Contains(attributeMarkEnd));

            var formattedItem = item.Replace(attributeMarkStart, string.Empty).Replace(attributeMarkEnd, string.Empty);

            if (hasAttribute)
                formattedItem = contentFormatter.GetFormattedContent(formattedItem);

            return BuildContentDto(originalContent, formattedItem);
        }
    }
}
