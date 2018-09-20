using StoryCreator.Web.Models.Rooms.Create;
using StoryCreator.Web.Models.Rooms.PersistenceDto;
using StoryTeller.Core.Rooms;
using System.Collections.Generic;
using System.Linq;

namespace StoryCreator.Web.Factories.Rooms
{
    public class RoomContentFactory
    {

        RoomContent MapCreateRoomContentVmToRoomContent(CreateRoomContentVm createRoomContet, string content, string roomId)
        {
            var roomContent = new RoomContent();

            roomContent.id = createRoomContet.Id;
            roomContent.roomId = roomId;
            roomContent.content = content;

            return roomContent;
        }


        public IEnumerable<CultureRoomContentPersistence> MapToCultureRoomContent(IEnumerable<CreateRoomContentVm> createRoomContents, string roomId)
        {
            var persList = new List<CultureRoomContentPersistence>();

            var cultures = createRoomContents.SelectMany(x => x.CultureContent).Select(x => x.Key).Distinct();

            foreach (var culture in cultures)
            {
                var persObj = new CultureRoomContentPersistence();
                persObj.culture = culture;
                persObj.roomContents = new List<RoomContent>();

                foreach (var item in createRoomContents)
                {
                    var cnt = MapCreateRoomContentVmToRoomContent(item, item.CultureContent[culture], roomId);
                    persObj.roomContents.Add(cnt);
                }

                persList.Add(persObj);
            }

            return persList;
        }
    }
}
