using System.Collections.Generic;
using Xamarin.Forms;

namespace StoryTellerTemplate.Models.GameContent
{
    public class RoomVm
    {
        public IEnumerable<Span> Content { get; set; }
        public IEnumerable<RoomActionVm> Actions { get; set; }
    }
}
