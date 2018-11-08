using System.Collections.Generic;
using Xamarin.Forms;

namespace StoryTellerTemplate.Interfaces.Views
{
    public interface IContentBinding
    {
        void BindTitle(string title);
        void BindImage(string image);
        void BindContentText(IEnumerable<Span> textSpans);
    }
}
