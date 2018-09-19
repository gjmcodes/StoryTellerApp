using StoryCreator.Web.Models.Rooms.Create;
using StoryTeller.Core.Rooms;
using StoryTeller.Core.Rooms.Aggregates;
using System.Collections.Generic;

namespace StoryCreator.Web.Factories.Rooms
{
    public class RoomFactory
    {
        public Room MapCreateRoomVmToRoom(CreateRoomVm createRoomVm)
        {
            var room = new Room(createRoomVm.Id, createRoomVm.RoomName);

            return room;
        }

        public RoomCreationAggregate MapRoomCreationAggregate(Room room, IEnumerable<RoomContent> roomContents, IEnumerable<RoomAction> roomActions)
        {
            var roomAggr = new RoomCreationAggregate(room, roomContents, roomActions);

            return roomAggr;
        }
    }
}
