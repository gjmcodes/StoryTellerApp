using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Interfaces.Repositories.Local;
using StoryTeller.Core.Interfaces.Services.Player;
using StoryTeller.Core.Interfaces.Services.Rooms;
using StoryTeller.Core.Rooms;

namespace StoryTeller.Core.Services.Rooms
{
    public class RoomService : IRoomEventService
    {
        private readonly IRoomLocalRepository _roomLocalRepository;
        private readonly IRoomExternalRepository _roomExternalRepository;

        private readonly IRoomActionService _roomActionService;
        private readonly IRoomEventService _roomEventService;
        private readonly IRoomContentService _roomContentService;

        private readonly IPlayerService _playerService;

        public RoomService()
        {
        }

        Room BuildRoom(Room room, IEnumerable<RoomAction> actions, RoomContent content)
        {
            room.Actions = actions;
            room.Content = content;

            return room;
        }

        public async Task<Room> GetRoomByIdAsync(string roomId)
        {

            var room = await _roomLocalRepository.GetRoomByIdAsync(roomId);
            if(room == null)
            {
                room = await _roomExternalRepository.GetRoomByIdAsync(roomId);
            }

            RoomContent roomContent = await _roomContentService.GetRoomDefaultContentAsync(roomId);

            var roomActions = await _roomActionService.GetRoomActionsAsync(roomId);

            var roomEvents = await _roomEventService.GetRoomEventsAsync(roomId);

            //Verificar se: caso há um event, se o jogador atende algum e caso sim qual content deverá ser
            // obtido para aquele Room.
            if (roomEvents.Count() > 0)
            {
                var playerStatusInventory = await _playerService.GetPlayerStatusInventoryAsync();
                var eventsWithConditionsMet = roomEvents.Where(x => x.PlayerMeetAnyConditions(playerStatusInventory));

                if(eventsWithConditionsMet.Count() > 0)
                {
                    var maxPriority = eventsWithConditionsMet.Max(x => x.EventPriority);
                    var priorityEvent = eventsWithConditionsMet.First(x => x.EventPriority == maxPriority);
                    roomContent = await _roomContentService.GetRoomContentByIdAsync(priorityEvent.RoomContentIdTriggeredByEvent);

                    return BuildRoom(room, roomActions, roomContent);
                }
            }

            return BuildRoom(room, roomActions, roomContent);
        }
    }
}
