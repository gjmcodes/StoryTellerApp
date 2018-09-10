using StoryTeller.Core.Text;
using System.Collections.Generic;

namespace StoryTeller.Core.Rooms
{
    public struct RoomContent
    {
        public string Id { get; private set; }
        public string RoomId { get; private set; }
        public IEnumerable<TextSpan> Content { get; private set; }
    }
}
