using StoryCreator.Web.Models.Contents;
using System.ComponentModel;

namespace StoryCreator.Web.Models.Rooms.Create
{
    public class CreateRoomContentVm
    {
        public string Id { get; set; }
        public string RoomId { get; set; }

        public string Content { get; set; }

        [Description("Cultura")]
        public string Culture { get; set; }
    }
}
