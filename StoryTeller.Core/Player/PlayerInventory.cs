using StoryTeller.Core.Inventory;
using System.Collections.Generic;

namespace StoryTeller.Core.Player
{
    public class PlayerInventory
    {
        public IEnumerable<Item> Items { get; private set; }
    }
}
