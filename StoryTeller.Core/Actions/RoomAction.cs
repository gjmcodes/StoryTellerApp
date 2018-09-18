using StoryTeller.Core.Actions;
using StoryTeller.Core.Enums.Actions;
using System;

namespace StoryTeller.Core.Rooms
{
    public struct RoomAction
    {
        public string id;
        public string roomId;
        public GameAction action;
    }
}
