using StoryCreator.Web.Models.Contents;
using StoryCreator.Web.Models.Rooms.Create;
using System.Collections.Generic;

namespace StoryCreator.Web.Models.Rooms.Create
{
    public class CreateRoomVm
    {
        public CreateRoomVm()
        {
            CreateRoomAction = new CreateRoomActionVm();
            CreateRoomContent = new CreateRoomContentVm();
            RoomActions = new List<CreateRoomActionVm>();
            RoomContent = new List<CreateRoomContentVm>();
        }

        public string Id { get; set; }
        public string RoomName { get; set; }

        public CreateRoomActionVm CreateRoomAction { get; set; }
        public CreateRoomContentVm CreateRoomContent{ get; set; }

        public List<CreateRoomActionVm> RoomActions { get; set; }
        public List<CreateRoomContentVm> RoomContent { get; set; }
    }
}
