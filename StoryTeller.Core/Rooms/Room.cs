using System.Collections.Generic;

namespace StoryTeller.Core.Rooms
{
    public class Room
    {
        public string Id { get; private set; }
        public string RoomName { get; private set; }

        public RoomContent Content { get; set; }
        public IEnumerable<RoomAction> Actions { get; set; }
    }
}
