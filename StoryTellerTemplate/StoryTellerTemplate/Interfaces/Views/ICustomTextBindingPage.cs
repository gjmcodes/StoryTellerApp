using System.Collections.Generic;
using Xamarin.Forms;

namespace StoryTellerTemplate.Interfaces.Views
{
    public interface ICustomTextBindingPage
    {
        void BindToViewModel();
        void BindContentText(IEnumerable<Span> textSpans);
    }
}
