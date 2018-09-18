using StoryTeller.Core.Enums.Actions;
using StoryTeller.Core.Enums.Rooms;

namespace StoryTellerTemplate.Models.RoomActions
{
    public class RoomActionVm
    {
        public ActionTypeEnum RoomActionType { get; private set; }
        public string RoomToNavigateId { get; private set; }
    }
}
