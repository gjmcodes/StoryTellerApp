using StoryTeller.Core.Enums.Rooms;
using StoryTeller.Core.Player;
using System.Collections.Generic;
using System.Linq;

namespace StoryTeller.Core.Rooms
{
    public class RoomEvent
    {
        public string Id { get; private set; }
        public string RoomId { get; private set; }
        public int EventPriority { get; private set; }
        public RoomEventType EventType { get; private set; }
        public string RoomContentIdTriggeredByEvent { get; private set; }
        public IEnumerable<RoomEventsCondition> ConditionsToTrigger { get; private set; }

        public bool PlayerMeetAnyConditions(PlayerStatusInventoryAggregate playerStatusInventory)
        {
            return ConditionsToTrigger.Where(x => x.PlayerMeetCondition(playerStatusInventory)).Count() > 0;
        }
    }
}
