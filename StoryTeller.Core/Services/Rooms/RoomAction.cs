using StoryTeller.Core.Actions;
using System.Collections.Generic;

namespace StoryTeller.Core.Rooms
{
    public struct RoomAction
    {
        public string id;
        public string roomId;
        public GameAction action;
    }
}
