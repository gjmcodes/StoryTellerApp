﻿using System.Collections.Generic;
using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.Text;
using StoryTeller.CrossCutting.Disposable;
using StoryTellerTemplate.Interfaces.Factories;
using Xamarin.Forms;

namespace StoryTellerTemplate.Factories
{
    public class TextSpanFactory : BaseFactory, ITextSpanFactory 
    {

        private readonly ICharacterDataTranslatorService _characterDataTranslatorService;
        private readonly INameCallTranslatorService _nameCallTranslatorService;

        public Span MapTextSpanToXamarinSpan(TextSpan textSpan)
        {
            if (textSpan.lineBreak)
                return new Span() { Text = textSpan.Content };

            string filteredContent = string.Empty;

            // Deverá tratar pronoum calls e character data aqui

            var span = new Span()
            {
                Text = textSpan.Content,
                FontSize = Device.GetNamedSize((NamedSize)textSpan.fontSize.GetHashCode(), typeof(Label)),
                BackgroundColor = Color.FromHex(textSpan.HexBackgroundColor),
                ForegroundColor = Color.FromHex(textSpan.HexForegroundColor),
                FontFamily =  textSpan.fontFamily,
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
