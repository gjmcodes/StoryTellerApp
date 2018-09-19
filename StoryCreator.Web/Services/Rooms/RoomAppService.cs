using StoryCreator.Web.Factories.Rooms;
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
        private readonly RoomFactory _roomFactory;
        private readonly RoomContentFactory _roomContentFactory;
        private readonly RoomActionFactory _roomActionFactory;

        public RoomAppService(IRoomService roomService,
             RoomFactory roomFactory,
             RoomContentFactory roomContentFactory,
            RoomActionFactory roomActionFactory)
        {
            _roomService = roomService;
            _roomFactory = roomFactory;
            _roomContentFactory = roomContentFactory;
            _roomActionFactory = roomActionFactory;
        }

        public async Task<OperationResult> CreateRoomAsync(CreateRoomVm roomVm)
        {
            var room = _roomFactory.MapCreateRoomVmToRoom(roomVm);
            var roomContents = _roomContentFactory.MapCreateRoomContentVmToRoomContent(roomVm.RoomContents, roomVm.Id);
            var roomActions = _roomActionFactory.MapCreateRoomActionToRoomAction(roomVm.RoomActions, roomVm.Id);

            var roomAggr = _roomFactory.MapRoomCreationAggregate(room, roomContents, roomActions);

            await _roomService.CreateRoomAsync(roomAggr, "EN");

            return new OperationResult();
        }
    }
}
