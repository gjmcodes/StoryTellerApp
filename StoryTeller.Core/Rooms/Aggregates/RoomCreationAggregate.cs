using System.Collections;
using System.Collections.Generic;

namespace StoryTeller.Core.Rooms.Aggregates
{
    public class RoomCreationAggregate
    {
        public RoomCreationAggregate(Room room, IEnumerable<RoomContent> roomContents, IEnumerable<RoomAction> roomActions)
        {
            Room = room;
            RoomContents = roomContents;
            RoomActions = roomActions;
        }

        public string RoomId => Room.Id;

        public Room Room { get; private set; }
        public IEnumerable<RoomContent> RoomContents { get; private set; }
        public IEnumerable<RoomAction> RoomActions { get; }
    }
}
