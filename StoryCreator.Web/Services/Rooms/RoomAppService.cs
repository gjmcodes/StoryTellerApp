using StoryCreator.Web.Factories.Rooms;
using StoryCreator.Web.Interfaces.Services.Rooms;
using StoryCreator.Web.Models.Results;
using StoryCreator.Web.Models.Rooms.Create;
using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Interfaces.Services.Rooms;
using System.Threading.Tasks;

namespace StoryCreator.Web.Services.Rooms
{
    public class RoomAppService : BaseAppService, IRoomAppService
    {
        private readonly IRoomService _roomService;
        private readonly IRoomExternalRepository _roomExternalRepository;
        private readonly IRoomActionExternalRepository _roomActionExternalRepository;
        private readonly IRoomContentExternalRepository _roomContentExternalRepository;

        private readonly RoomFactory _roomFactory;
        private readonly RoomContentFactory _roomContentFactory;
        private readonly RoomActionFactory _roomActionFactory;

        public RoomAppService(IRoomService roomService,
             RoomFactory roomFactory,
             RoomContentFactory roomContentFactory,
            RoomActionFactory roomActionFactory,
            IRoomExternalRepository roomExternalRepository,
            IRoomActionExternalRepository roomActionExternalRepository,
            IRoomContentExternalRepository roomContentExternalRepository)
        {
            _roomService = roomService;
            _roomFactory = roomFactory;
            _roomContentFactory = roomContentFactory;
            _roomActionFactory = roomActionFactory;

            _roomExternalRepository = roomExternalRepository;
            _roomActionExternalRepository = roomActionExternalRepository;
            _roomContentExternalRepository = roomContentExternalRepository;
        }

        public async Task<OperationResult> CreateRoomAsync(CreateRoomVm roomVm)
        {
            var rooms = _roomFactory.MapCultureRoomPersistence(roomVm);

            var roomContents = _roomContentFactory.MapToCultureRoomContent(roomVm.RoomContents, roomVm.Id);
            var roomActions = _roomActionFactory.MapToCultureRoomAction(roomVm.RoomActions, roomVm.Id);

            //var roomAggr = _roomFactory.MapRoomCreationAggregate(room);

            foreach (var roomCulture in rooms)
            {
                await _roomExternalRepository.CreateRoomAsync(roomCulture.room, roomCulture.culture);
            }

            foreach (var item in roomContents)
            {
                await _roomContentExternalRepository.CreateRoomContentsAsync(item.roomContents, item.culture);
            }

            foreach (var item in roomActions)
            {
                await _roomActionExternalRepository.CreateRoomActionsAsync(item.roomActions, item.culture);
            }



            return new OperationResult();
        }
    }
}
