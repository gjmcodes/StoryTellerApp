using StoryCreator.Web.Models.Rooms.Create;
using StoryTeller.Core.Rooms;
using System.Collections.Generic;

namespace StoryCreator.Web.Factories.Rooms
{
    public class RoomContentFactory
    {

        public RoomContent MapCreateRoomContentVmToRoomContent(CreateRoomContentVm createRoomContet, string roomId)
        {
            var roomContent = new RoomContent();
            roomContent.id = createRoomContet.Id;
            roomContent.roomId = roomId;
            roomContent.content = createRoomContet.Content;

            return roomContent;
        }

        public IEnumerable<RoomContent> MapCreateRoomContentVmToRoomContent(IEnumerable<CreateRoomContentVm> createRoomContets, string roomId)
        {
            var objs = new List<RoomContent>();

            foreach (var item in createRoomContets)
            {
                var obj = MapCreateRoomContentVmToRoomContent(item, roomId);
                objs.Add(obj);
            }

            return objs;
        }
    }
}
