using StoryTellerTemplate.Models.GameContent;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StoryTellerTemplate.Models.MainPage
{
    public class PageVm
    {
        public IEnumerable<GameActionVm> Actions { get; set; }
        public IEnumerable<Span> Content { get; set; }
    }
}
