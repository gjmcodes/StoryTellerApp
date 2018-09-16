using StoryTeller.Core.Interfaces.Services.Rooms;
using StoryTeller.CrossCutting.User.Interfaces.Services;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Models.MainPage;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Services.GameContent
{
    public class GameContentAppService : BaseAppService, IGameContentAppService
    {
        private readonly IRoomService _roomService;
        private readonly IUserStatusService _userStatusService;
        private readonly ITextSpanFactory _textSpanFactory;

        public GameContentAppService(IRoomService roomService, 
            IUserStatusService userStatusService,
            ITextSpanFactory textSpanFactory)
        {
            _roomService = roomService;
            _userStatusService = userStatusService;
            _textSpanFactory = textSpanFactory;
        }


        async Task<RoomVm> BuildRoomVmAsync(string roomId)
        {
            var roomData = await _roomService.GetRoomByIdAsync(roomId);
            var textSpans = _textSpanFactory.MapTextSpanToXamarinSpan(roomData.Content.content);
            var roomVm = new RoomVm();
            roomVm.Content = textSpans;

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
