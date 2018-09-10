using System.Collections;
using System.Collections.Generic;

namespace StoryTeller.Core.Player
{
    public class PlayerStatusInventoryAggregate
    {
        public PlayerInventory PlayerInventory { get; set; }
        public IEnumerable<PlayerStatus> Statuses { get; set; }
    }
}
