using StoryTeller.Core.Enums.Rooms;
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

        public RoomActionType actionTypeEnum => (RoomActionType)Enum.Parse(typeof(RoomActionType), roomActionType);
    }
}
