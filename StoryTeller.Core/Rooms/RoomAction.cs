using StoryTeller.Core.Enums.Rooms;

namespace StoryTeller.Core.Rooms
{
    public class RoomAction
    {
        public string Id { get; private set; }
        public string RoomId { get; private set; }
        public string Description { get; private set; }
        public RoomActionType ActionType { get; private set; }
        public string RoomToNavigateId { get; private set; }
    }
}
