using System.Collections.Generic;
using Xamarin.Forms;

namespace StoryTellerTemplate.Interfaces.Views
{
    public interface IContentBinding
    {
        void BindContentText(IEnumerable<Span> textSpans);
    }
}
