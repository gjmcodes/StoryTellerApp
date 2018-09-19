using System.Collections;

namespace StoryTeller.Core.Rooms.Aggregates
{
    public class RoomCreationAggregate
    {
        public RoomCreationAggregate(Room room, RoomContent roomContent, RoomAction roomAction)
        {
            Room = room;
            RoomContent = roomContent;
            RoomAction = roomAction;
        }

        public string RoomId => Room.Id;

        public Room Room { get; private set; }
        public RoomContent RoomContent { get; private set; }
        public RoomAction RoomAction { get; private set; }
    }
}
