using StoryTeller.Core.Text;
using System.Collections.Generic;

namespace StoryTeller.Core.Rooms
{
    public struct RoomContent
    {
        public string id;
        public string roomId;
        public string content;

        public IEnumerable<TextSpan> textSpans;
    }
}
