using StoryCreator.Web.Models.Rooms.Create;
using StoryCreator.Web.Models.Rooms.PersistenceDto;
using StoryTeller.Core.Rooms;
using System.Collections.Generic;
using System.Linq;

namespace StoryCreator.Web.Factories.Rooms
{
    public class RoomFactory
    {
        Room MapCreateRoomVmToRoom(string id, string roomName)
        {
            var room = new Room(id, roomName);

            return room;
        }

        public IEnumerable<CultureRoomPersistence> MapRoomCreationAggregate(CreateRoomVm roomVm)
        {
            var cultureRoomPersistence = new CultureRoomPersistence();

            var cultures = roomVm.CultureNames.Select(x => x.Key).Distinct();

            var persList = new List<CultureRoomPersistence>();

            foreach (var culture in cultures)
            {
                var persObj = new CultureRoomPersistence();
                persObj.culture = culture;

                var room = MapCreateRoomVmToRoom(roomVm.Id, roomVm.CultureNames[culture]);

                persObj.rooms.Add(room);

                persList.Add(persObj);
            }


            return persList;
        }
    }
}
