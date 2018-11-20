using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StoryTeller.Core.Enums.Text;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.Text;
using StoryTeller.Xamarin.Domain.Entities.Pages;
using StoryTellerTemplate.Interfaces.Factories;
using Xamarin.Forms;

namespace StoryTellerTemplate.Factories
{
    public class TextSpanFactory : BaseFactory, ITextSpanFactory
    {
        private readonly IPronoumTranslatorService _pronoumTranslatorService;
        private readonly ICharacterDataTranslatorService _characterDataTranslatorService;

        public TextSpanFactory(IPronoumTranslatorService pronoumTranslatorService,
            ICharacterDataTranslatorService characterDataTranslatorService)
        {
            _pronoumTranslatorService = pronoumTranslatorService;
            _characterDataTranslatorService = characterDataTranslatorService;
        }

        public async Task<IEnumerable<Span>> MapContentToSpanAsync(IEnumerable<XamarinPageContent> pageContent)
        {
            var spans = new List<Span>();

            foreach (var item in pageContent)
            {
                var span = await MapTextSpanToXamarinSpanAsync(item);

                spans.Add(span);
            }

            return spans;
        }

        async Task<Span> MapTextSpanToXamarinSpanAsync(XamarinPageContent pageContent)
        {

            if (pageContent.LineBreak)
            {
                return new Span() { Text = pageContent.GetContent };
            };

            string content = pageContent.GetContent;

            if (_pronoumTranslatorService.HasPronoumMarkers(pageContent.GetContent))
                content = await _pronoumTranslatorService.TranslatePronoumAsync(pageContent.GetContent);

            if (_characterDataTranslatorService.HasCharacterDataMarkers(content))
                content = await _characterDataTranslatorService.TranslateCharacterDataAsync(content);

            // Deverá tratar pronoum calls e character data aqui
            var span = new Span()
            {
                Text = content,
                FontSize = Device.GetNamedSize((NamedSize)pageContent.FontSize.GetHashCode(), typeof(Label)),
                BackgroundColor = Color.FromHex(pageContent.GetHexBackgroundColor),
                ForegroundColor = Color.FromHex(pageContent.GetHexForegroundColor),
                FontFamily = pageContent.FontFamily,
                FontAttributes = (FontAttributes)pageContent.FontAttribute.GetHashCode()
            };


            return span;
        }


        protected override void ReleaseResources()
        {
            _pronoumTranslatorService.Dispose();
        }
    }
}
