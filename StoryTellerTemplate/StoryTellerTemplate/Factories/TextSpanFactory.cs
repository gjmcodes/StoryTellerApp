using System.Collections.Generic;
using StoryTeller.Core.Pages;
using StoryTellerTemplate.Interfaces.Factories;
using Xamarin.Forms;

namespace StoryTellerTemplate.Factories
{
    public class TextSpanFactory : ITextSpanFactory
    {
        public Span MapTextSpanToXamarinSpan(TextSpan textSpan)
        {
            if (textSpan.IsNewLine)
                return new Span() { Text = textSpan.content };

            var span = new Span()
            {
                Text = textSpan.content,
                FontSize = Device.GetNamedSize((NamedSize)textSpan.fontSize.GetHashCode(), typeof(Label)),
                BackgroundColor = Color.FromHex(textSpan.hexBackgroundColor),
                ForegroundColor = Color.FromHex(textSpan.hexForegroundColor),
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
    }
}
