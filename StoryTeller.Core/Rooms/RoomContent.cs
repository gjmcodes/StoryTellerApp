using StoryTeller.Core.Text;
using System.Collections.Generic;

namespace StoryTeller.Core.Rooms
{
    public struct RoomContent
    {
        public string id;
        public string roomId;
        public IEnumerable<TextSpan> content;
    }
}
