using StoryCreator.Web.Interfaces.Services.Rooms;
using StoryCreator.Web.Models.Results;
using StoryCreator.Web.Models.Rooms.Create;
using StoryTeller.Core.Interfaces.Services.Rooms;
using System.Threading.Tasks;

namespace StoryCreator.Web.Services.Rooms
{
    public class RoomAppService : BaseAppService, IRoomAppService
    {
        private readonly IRoomService _roomService;

        public RoomAppService(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task<OperationResult> CreateRoomAsync(CreateRoomVm roomVm)
        {

        }
    }
}
