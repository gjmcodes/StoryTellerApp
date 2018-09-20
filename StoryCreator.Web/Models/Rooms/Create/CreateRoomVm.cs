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
            RoomContents = new List<CreateRoomContentVm>();
        }

        public CreateRoomVm(IEnumerable<string> cultures)
        {
            this.Cultures = cultures;
            CreateRoomAction = new CreateRoomActionVm(cultures);
            CreateRoomContent = new CreateRoomContentVm(cultures);
            RoomActions = new List<CreateRoomActionVm>();
            RoomContents = new List<CreateRoomContentVm>();
        }

        public string Id { get; set; }
        public string RoomName { get; set; }

        public CreateRoomActionVm CreateRoomAction { get; set; }
        public CreateRoomContentVm CreateRoomContent{ get; set; }

        public List<CreateRoomActionVm> RoomActions { get; set; }
        public List<CreateRoomContentVm> RoomContents { get; set; }

        public IEnumerable<string> Cultures { get; set; }
    }
}
