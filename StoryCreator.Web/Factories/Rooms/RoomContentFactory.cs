using StoryCreator.Web.Models.Rooms.Create;
using StoryTeller.Core.Rooms;
using System.Collections.Generic;

namespace StoryCreator.Web.Factories.Rooms
{
    public class RoomContentFactory
    {
        private readonly StoryTeller.Core.ContentTranslation.ContentMarkupTranslator _contentMarkupTranslator;

        public RoomContentFactory(StoryTeller.Core.ContentTranslation.ContentMarkupTranslator contentMarkupTranslator)
        {
            _contentMarkupTranslator = contentMarkupTranslator;
        }

        public RoomContent MapCreateRoomContentVmToRoomContent(CreateRoomContentVm createRoomContet, string roomId)
        {
            var roomContent = new RoomContent();
            roomContent.id = createRoomContet.Id;
            roomContent.roomId = roomId;

            var contents = _contentMarkupTranslator.Translate(createRoomContet.Content);

            roomContent.content = contents;

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
