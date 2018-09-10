using StoryTeller.Core.Enums.Rooms;
using StoryTeller.Core.Player;
using System.Collections.Generic;
using System.Linq;

namespace StoryTeller.Core.Rooms
{
    public struct RoomEventsCondition
    {
        public string Id { get; private set; }
        public string RoomEventId { get; private set; }
        public RoomEventsConditionType ConditionType { get; private set; }
        public IEnumerable<string> ItemsIds { get; private set; }
        public string StatusId { get; private set; }


        public bool PlayerMeetCondition(PlayerStatusInventoryAggregate playerStatusInventory)
        {
            // Verificar se pelos itens obtidos ou pelos status gravados em banco
            // se o jogador atende a este requisito

            if (ConditionType == RoomEventsConditionType.Items)
                return ItemsIds.Intersect(playerStatusInventory.PlayerInventory.Items.Select(x => x.Id).ToArray()).Count() > 0;

            return playerStatusInventory.Statuses.Select(x => x.StatusId).Contains(StatusId);
        }
    }
}
