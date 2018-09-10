using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Interfaces.Repositories.Local;
using StoryTeller.Core.Interfaces.Services.Rooms;
using StoryTeller.Core.Rooms;

namespace StoryTeller.Core.Services.Rooms
{
    public class RoomActionService : IRoomActionService
    {
        private readonly IRoomActionLocalRepository _roomActionLocalRepository;
        private readonly IRoomActionExternalRepository _roomActionExternalRepository;

        public RoomActionService()
        {
        }

        public async Task<IEnumerable<RoomAction>> GetRoomActionsAsync(string roomId)
        {
            var roomActions = await _roomActionLocalRepository.GetRoomActionsAsync(roomId);

            if (roomActions?.Count() > 0)
                return roomActions;

            roomActions = await _roomActionExternalRepository.GetRoomActionsAsync(roomId);

            return roomActions;
        }
    }
}
