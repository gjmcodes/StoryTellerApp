using StoryTeller.Core.Rooms;
using System.Collections.Generic;

namespace StoryCreator.Web.Models.Rooms.PersistenceDto
{
    public struct CultureRoomContentPersistence
    {
        public string culture;
        public IList<RoomContent> roomContents;
    }
}
