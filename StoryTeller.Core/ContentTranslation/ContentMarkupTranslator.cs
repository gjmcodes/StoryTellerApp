using StoryTeller.Core.Text;
using StoryTeller.CrossCutting.Disposable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StoryTeller.Core.ContentTranslation
{
    public class ContentMarkupTranslator : DisposableObject
    {
        readonly FontAttributeTranslator _fontAttributeTranslator;

        public ContentMarkupTranslator()
        {
            _fontAttributeTranslator = new FontAttributeTranslator();
        }

        public const string paragraphStart = "<p>";
        public const string paragraphEnd = "</p>";
        public const string paragraphEndRegexEscape = @"<\/p>";


        public IEnumerable<TextSpan> Translate(string content)
        {
            var textSpans = new List<TextSpan>();

            var contents = BreakIntoParagraphs(content);
            contents = BreakFontAttributes(contents);

            return textSpans;
        }

        IEnumerable<ContentTranslationDto> BreakIntoParagraphs(string content)
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
                    dto.amountLineBreaks = 2;
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

        IEnumerable<ContentTranslationDto> BreakFontAttributes(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = _fontAttributeTranslator.BreakAttributes(paragraphedContents);

            return contents;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
