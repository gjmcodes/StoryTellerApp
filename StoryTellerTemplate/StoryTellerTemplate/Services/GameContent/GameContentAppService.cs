using StoryTeller.Core.Interfaces.Services.Rooms;
using StoryTeller.Core.Rooms;
using StoryTeller.CrossCutting.User.Interfaces.Services;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.Models.MainPage;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Services.GameContent
{
    public class GameContentAppService : BaseAppService, IGameContentAppService
    {
        private readonly IRoomService _roomService;
        private readonly IUserStatusService _userStatusService;
        private readonly ITextSpanFactory _textSpanFactory;
        private readonly IRoomVmFactory _roomVmFactory;

        public GameContentAppService(IRoomService roomService, 
            IUserStatusService userStatusService,
            ITextSpanFactory textSpanFactory,
            IRoomVmFactory roomVmFactory)
        {
            _roomService = roomService;
            _userStatusService = userStatusService;
            _textSpanFactory = textSpanFactory;
            _roomVmFactory = roomVmFactory;
        }


        async Task<RoomVm> BuildRoomVmAsync(string roomId)
        {
            var roomData = await _roomService.GetRoomByIdAsync(roomId);
            var roomVm = _roomVmFactory.MapRoomToRoomVm(roomData);

            return roomVm;
        }

        public async Task<RoomVm> GetCurrentRoomDataAsync()
        {
            var currentRoomId = await _userStatusService.GetCurrentRoomIdAsync();
            var vm = await BuildRoomVmAsync(currentRoomId);

            return vm;
        }

        public async Task<RoomVm> GetRoomDataAsync(string roomId)
        {
            return await BuildRoomVmAsync(roomId);
        }
    }
}
