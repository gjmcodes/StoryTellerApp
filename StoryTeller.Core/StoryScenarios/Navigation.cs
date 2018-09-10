using StoryTeller.Core.Interfaces.Services.Player;
using System.Collections.Generic;
using System.Linq;

namespace StoryTeller.Core.StoryScenarios
{

    public struct NavigationResult
    {
        public NavigationResult(bool canNavigate, ScenarioRoom nextRoom)
        {
            this.canNavigate = canNavigate;
            this.nextRoom = nextRoom;
        }

        public bool canNavigate;
        public ScenarioRoom nextRoom;
    }

    public class Navigation
    {
        private readonly IEnumerable<ScenarioRoom> rooms;
        private readonly IPlayerAchievmentInRoomService playerStatusInRoomService;

        private ScenarioRoom currentRoom;

        public Navigation(IEnumerable<ScenarioRoom> rooms, ScenarioRoom currentRoom)
        {
            this.rooms = rooms;
            this.currentRoom = currentRoom;
        }

        public ScenarioRoom NavigateToRoom(string roomId)
        {
            // Obter status do jogador para o roomId;
            var playerStatusInRoom = playerStatusInRoomService.GetPlayerStatusInRoomById(roomId);

            var room = rooms.First(x => x.Id == roomId);

            this.currentRoom = room;

            return room;
        }
    }
}
