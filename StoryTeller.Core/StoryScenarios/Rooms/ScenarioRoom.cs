//using StoryTeller.Core.Player;
//using StoryTeller.Core.StoryScenarios.Pages;
//using StoryTeller.Core.StoryScenarios.Rooms;
//using System.Collections.Generic;

//namespace StoryTeller.Core.StoryScenarios
//{
//    public class ScenarioRoom
//    {
//        public ScenarioRoom(StoryPage roomPage)
//        {
//            this.RoomPage = roomPage;
//        }
//        public string Id { get; private set; }
//        public RoomActionAchievmentRequirements RoomActionRequirements { get; private set; }

//        public StoryPage RoomPage { get; private set; }
//        public IEnumerable<Character> Characters { get; private set; }
//        public IEnumerable<ScenarioRoom> NeighborRooms { get; private set; }

//        public bool RequirementsForActionAreMet(PlayerAchievmentInRoom playerStatusInThisRoom)
//        {
//            return true;
//        }
//    }
//}
