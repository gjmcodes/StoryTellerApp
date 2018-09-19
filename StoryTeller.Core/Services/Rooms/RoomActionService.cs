using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Interfaces.Repositories.Local;
using StoryTeller.Core.Interfaces.Services.Rooms;
using StoryTeller.Core.Rooms;

namespace StoryTeller.Core.Services.Rooms
{
    public class RoomActionService : BaseService, IRoomActionService
    {
        private readonly IRoomActionLocalRepository _roomActionLocalRepository;
        private readonly IRoomActionExternalRepository _roomActionExternalRepository;

        public RoomActionService(IRoomActionExternalRepository roomActionExternalRepository)
        {
            _roomActionExternalRepository = roomActionExternalRepository;
        }

        public Task CreateRoomActionsAsync(IEnumerable<RoomAction> roomaActions, string culture)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<RoomAction>> GetRoomActionsAsync(string roomId)
        {
            //var roomActions = await _roomActionLocalRepository.GetRoomActionsAsync(roomId);

            //if (roomActions?.Count() > 0)
            //    return roomActions;

            var roomActions = await _roomActionExternalRepository.GetRoomActionsAsync(roomId);

            return roomActions;
        }
    }
}
