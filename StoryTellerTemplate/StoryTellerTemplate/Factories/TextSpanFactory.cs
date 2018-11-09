using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.Enums.Text;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.Text;
using StoryTeller.CrossCutting.Disposable;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTellerTemplate.Interfaces.Factories;
using Xamarin.Forms;

namespace StoryTellerTemplate.Factories
{
    public class TextSpanFactory : BaseFactory, ITextSpanFactory
    {
        private readonly IPronoumTranslatorService _pronoumTranslatorService;

        public TextSpanFactory(IPronoumTranslatorService pronoumTranslatorService)
        {
            _pronoumTranslatorService = pronoumTranslatorService;
        }

        public async Task<IEnumerable<Span>> MapContentDtoToSpanAsync(IEnumerable<PageContentDto> pageContentDtos)
        {
            return await Task.Run(async () =>
            {
                var spans = new List<Span>();

                var textSpans = new List<TextSpan>();

                foreach (var item in pageContentDtos)
                {
                    var content = item.Content;

                    if (_pronoumTranslatorService.HasPronoumMarkers(item.Content))
                        content = await _pronoumTranslatorService.TranslatePronoumAsync(item.Content);

                    var textSpan = new TextSpan();

                    textSpan.amountLineBreaks = item.AmountLineBreaks;
                    textSpan.content = content;
                    textSpan.fontAttribute = (FontAttribute)item.FontAttribute;
                    textSpan.fontFamily = item.FontFamily;
                    textSpan.fontSize = (FontNamedSize)item.FontSize;
                    textSpan.hexBackgroundColor = item.HexBackgroundColor;
                    textSpan.hexForegroundColor = item.HexForegroundColor;
                    textSpan.lineBreak = item.LineBreak;

                    textSpans.Add(textSpan);
                }

                foreach (var item in textSpans)
                {
                    spans.Add(MapTextSpanToXamarinSpan(item));
                }

                return spans;
            });
        }

        public Span MapTextSpanToXamarinSpan(TextSpan textSpan)
        {
            if (textSpan.lineBreak)
            {
                var spanText = new StringBuilder();

                for (int i = 0; i < textSpan.amountLineBreaks; i++)
                {
                    spanText.Append(Environment.NewLine);
                    spanText.Append(" ");
                }
                return new Span() { Text = spanText.ToString() };
            };

            string filteredContent = string.Empty;

            // Deverá tratar pronoum calls e character data aqui
            var span = new Span()
            {
                Text = textSpan.Content,
                FontSize = Device.GetNamedSize((NamedSize)textSpan.fontSize.GetHashCode(), typeof(Label)),
                BackgroundColor = Color.FromHex(textSpan.HexBackgroundColor),
                ForegroundColor = Color.FromHex(textSpan.HexForegroundColor),
                FontFamily = textSpan.fontFamily,
                FontAttributes = (FontAttributes)textSpan.fontAttribute.GetHashCode()
            };


            return span;
        }

        public IEnumerable<Span> MapTextSpanToXamarinSpan(IEnumerable<TextSpan> textSpan)
        {
            var spans = new List<Span>();

            foreach (var item in textSpan)
            {
                var span = MapTextSpanToXamarinSpan(item);
                spans.Add(span);
            }

            return spans;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
