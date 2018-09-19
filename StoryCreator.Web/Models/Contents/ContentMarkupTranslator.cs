using StoryCreator.Web.Models.Contents.ContentTranslator;
using StoryTeller.Core.Enums.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StoryCreator.Web.Models.Contents
{
    public class ContentMarkupTranslator
    {
        public const string paragraphStart = "<p>";
        public const string paragraphEnd = "</p>";
        public const string paragraphEndRegexEscape = @"<\/p>";

        static FontAttributeTranslator _fontAttributeTranslator;

        public static IEnumerable<ContentViewModel> Translate(string content)
        {
            var contentVms = new List<ContentViewModel>();
            var contents = BreakIntoParagraphs(content);
            contents = BreakFontAttributes(contents);

            return contentVms;
        }

        static IEnumerable<ContentTranslationDto> BreakIntoParagraphs(string content)
        {

            var contents = Regex.Split(content.Replace(Environment.NewLine, string.Empty), $@"(<p>[\s\S]+?<\/p>)").ToList();
            var formattedContents = new List<string>();
            var dtos = new List<ContentTranslationDto>();

            foreach (var item in contents)
            {
                var dto = new ContentTranslationDto();

                var formattedItem = item.Replace(paragraphStart, string.Empty).Replace(paragraphEnd, string.Empty).Trim();
                if (string.IsNullOrEmpty(formattedItem))
                {
                    dto.lineBreak = true;
                    dto.amountLineBreaks= 2;
                    dto.content = string.Empty;
                }
                else
                {
                    dto.content = formattedItem;
                }

                dtos.Add(dto);
            }

            return dtos;
        }

        static IEnumerable<ContentTranslationDto> BreakFontAttributes(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            _fontAttributeTranslator = new FontAttributeTranslator();

            var contents = _fontAttributeTranslator.BreakAttributes(paragraphedContents);

            return contents;
        }

        static ContentViewModel CopyIntoNewContentViewModel(ContentViewModel original, string newContent)
        {
            var newContVm = new ContentViewModel()
            {
                AmountLineBreaks = original.AmountLineBreaks,
                FontAttribute = original.FontAttribute,
                FontFamily = original.FontFamily,
                FontSize = original.FontSize,
                HexBackgroundColor = original.HexBackgroundColor,
                HexForegroundColor = original.HexBackgroundColor,
                LineBreak = original.LineBreak,
                Content = newContent
            };

            return newContVm;
        }
    }
}
