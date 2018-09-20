using StoryTeller.Core.Rooms;
using System.Collections.Generic;

namespace StoryCreator.Web.Models.Rooms.PersistenceDto
{
    public struct CultureRoomActionPersistence
    {
        public string culture;
        public IList<RoomAction> roomActions;
    }
}
