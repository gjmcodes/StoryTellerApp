using StoryTeller.Core.Text;
using StoryTeller.CrossCutting.Disposable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation
{
    public class ContentMarkupTranslator : DisposableObject
    {
        readonly FontAttributeTranslator _fontAttributeTranslator;
        readonly CharacterDataTranslator _characterDataTranslator;
        readonly NameCallTranslator _nameCallTranslator;

        public ContentMarkupTranslator()
        {
            _fontAttributeTranslator = new FontAttributeTranslator();
            _characterDataTranslator = new CharacterDataTranslator();
            _nameCallTranslator = new NameCallTranslator();
        }

        public const string paragraphStart = "<p>";
        public const string paragraphEnd = "</p>";
        public const string paragraphEndRegexEscape = @"<\/p>";


        public async Task<IEnumerable<TextSpan>> TranslateAsync(string content)
        {
            var textSpans = new List<TextSpan>();

            var contents = BreakIntoParagraphs(content);
            contents = await BreakFontAttributesAsync(contents);
            contents = await BreakCharacterDataAsync(contents);
            contents = await BreakNameCallsAsync(contents);

            foreach (var item in contents)
            {
                var span = new TextSpan()
                {
                    amountLineBreaks = item.amountLineBreaks,
                    content = item.content,
                    fontAttribute = item.fontAttribute,
                    fontFamily = item.fontFamily,
                    fontSize = item.fontSize,
                    hexBackgroundColor = item.hexBackgroundColor,
                    hexForegroundColor = item.hexForegroundColor,
                    lineBreak = item.lineBreak
                };

                textSpans.Add(span);
            }

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

        async Task<IEnumerable<ContentTranslationDto>> BreakFontAttributesAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = await _fontAttributeTranslator.BreakAttributesAsync(paragraphedContents);

            return contents;
        }

        async Task<IEnumerable<ContentTranslationDto>> BreakCharacterDataAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = await _characterDataTranslator.BreakCharacterDataAsync(paragraphedContents);

            return contents;
        }

        async Task<IEnumerable<ContentTranslationDto>> BreakNameCallsAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = await _nameCallTranslator.BreakNameCallsAsync(paragraphedContents);

            return contents;
        }


        protected override void ReleaseResources()
        {
        }
    }
}
