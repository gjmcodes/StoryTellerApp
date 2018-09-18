using System.Collections.Generic;
using Xamarin.Forms;

namespace StoryTellerTemplate.Interfaces.Views
{
    public interface IRoomContentBinding
    {
        void BindContentText(IEnumerable<Span> textSpans);
    }
}
