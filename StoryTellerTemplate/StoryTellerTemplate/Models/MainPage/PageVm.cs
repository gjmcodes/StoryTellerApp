using StoryTellerTemplate.Models.GameContent;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StoryTellerTemplate.Models.MainPage
{
    public class PageVm
    {
        public List<GameActionVm> Actions { get; set; }
        public List<Span> Content { get; set; }
    }
}
