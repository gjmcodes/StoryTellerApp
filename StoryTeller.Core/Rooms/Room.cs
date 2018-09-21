using System.Collections.Generic;

namespace StoryTeller.Core.Rooms
{
    public class Room
    {
        public Room(){}

        public Room(string id, string roomName)
        {
            RoomId = id;
            RoomName = roomName;
        }

        public string RoomId { get; private set; }
        public string RoomName { get; private set; }

        public RoomContent content;
        public IEnumerable<RoomAction> Actions { get; set; }
    }
}
