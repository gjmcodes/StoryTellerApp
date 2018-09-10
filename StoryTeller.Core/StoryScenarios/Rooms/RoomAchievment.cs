using System.Collections.Generic;

namespace StoryTeller.Core.StoryScenarios.Rooms
{
    public class RoomAchievment
    {
        public string Id { get; private set; }
        public string RoomId { get; private set; }
        public string Description { get; private set; }
        public int SuccessRatio { get; private set; }
    }
}
