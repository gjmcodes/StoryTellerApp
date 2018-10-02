using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.ContentTranslation
{
    public class ContentMarkupTranslatorService : BaseService, IContentMarkupTranslatorService
    {
        private readonly IFontAttributeTranslatorService _fontAttributeTranslatorService;
        private readonly ICharacterDataTranslatorService _characterDataTranslatorService;
        private readonly INameCallTranslatorService _nameCallTranslatorService;
        private readonly IParagraphTranslatorService _paragraphTranslatorService;

        public ContentMarkupTranslatorService(
            IFontAttributeTranslatorService fontAttributeTranslatorService, 
            ICharacterDataTranslatorService characterDataTranslatorService, 
            INameCallTranslatorService nameCallTranslatorService, 
            IParagraphTranslatorService paragraphTranslatorService)
        {
            _fontAttributeTranslatorService = fontAttributeTranslatorService;
            _characterDataTranslatorService = characterDataTranslatorService;
            _nameCallTranslatorService = nameCallTranslatorService;
            _paragraphTranslatorService = paragraphTranslatorService;
        }

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
            var contents = _paragraphTranslatorService.BreakIntoParagraphs(content);

            return contents;
        }


        async Task<IEnumerable<ContentTranslationDto>> BreakFontAttributesAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = await _fontAttributeTranslatorService.BreakAttributesAsync(paragraphedContents);

            return contents;
        }

        async Task<IEnumerable<ContentTranslationDto>> BreakCharacterDataAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = await _characterDataTranslatorService.BreakCharacterDataAsync(paragraphedContents);

            return contents;
        }

        async Task<IEnumerable<ContentTranslationDto>> BreakNameCallsAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = await _nameCallTranslatorService.BreakNameCallsAsync(paragraphedContents);

            return contents;
        }


        protected override void ReleaseResources()
        {
            _fontAttributeTranslatorService.Dispose();
            _characterDataTranslatorService.Dispose();
            _nameCallTranslatorService.Dispose();

            base.ReleaseResources();
        }
    }
}
