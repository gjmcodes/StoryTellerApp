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
            RoomActions = new List<CreateRoomActionVm>();
            RoomContent = new List<ContentViewModel>();
        }

        public string Id { get; set; }
        public string RoomName { get; set; }

        public CreateRoomActionVm CreateRoomAction { get; set; }
        public List<CreateRoomActionVm> RoomActions { get; set; }
        public List<ContentViewModel> RoomContent { get; set; }
    }
}
