using StoryTeller.Core.Enums.Actions;
using StoryTeller.Core.Enums.Rooms;
using StoryTeller.Core.Player;
using System.Collections.Generic;

namespace StoryTeller.Core.StoryScenarios.Rooms
{
    public class RoomActionAchievmentRequirements
    {
        public ActionTypeEnum Action { get; private set; }
        public string RoomAchievmentId { get; private set; }
        public int MinimumRoomAchievmentSuccessRatio { get; private set; }
    }
}
