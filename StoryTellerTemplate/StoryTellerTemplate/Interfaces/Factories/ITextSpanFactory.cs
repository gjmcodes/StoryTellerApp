using StoryTeller.Core.Text;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface ITextSpanFactory : IBaseFactory
    {
        IEnumerable<Span> MapTextSpanToXamarinSpan(IEnumerable<TextSpan> textSpan);
    }
}
