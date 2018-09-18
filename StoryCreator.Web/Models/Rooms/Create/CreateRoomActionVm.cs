using StoryTeller.Core.Enums.Actions;
using System.ComponentModel;

namespace StoryCreator.Web.Models.Rooms.Create
{
    public class CreateRoomActionVm
    {
        public string Id { get; set; }

        [Description("Descrição")]
        public string Description { get; set; }

        [Description("Id Para Room")]
        public string RoomToNavigateId { get; set; }

        [Description("Id Para Dialogue")]
        public string DialogueToOpenId { get; set; }

        [Description("Ação")]
        public ActionTypeEnum ActionType { get; set; }
    }
}
