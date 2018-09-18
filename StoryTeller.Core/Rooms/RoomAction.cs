using StoryTeller.Core.Enums.Actions;
using System;

namespace StoryTeller.Core.Rooms
{
    public struct RoomAction
    {
        public string id;
        public string roomId;
        public string description;
        public string roomActionType;
        public string roomToNavigateId;

        public ActionTypeEnum actionTypeEnum => (ActionTypeEnum)Enum.Parse(typeof(ActionTypeEnum), roomActionType);
    }
}
