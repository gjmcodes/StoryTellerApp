using StoryTeller.Core.Enums.Actions;
using StoryTeller.Core.Enums.Rooms;
using StoryTeller.Core.Interfaces.Services.Rooms;
using StoryTeller.CrossCutting.User.Interfaces.Services;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Interfaces.Services.RoomActions;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.Models.RoomActions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTellerTemplate.Services.RoomActions
{
    public class RoomActionAppService : BaseAppService, IRoomActionAppService
    {
        private readonly IRoomService _roomService;
        private readonly IUserStatusService _userStatusService;
        private readonly ITextSpanFactory _textSpanFactory;

        public RoomActionAppService(IRoomService roomService,
            IUserStatusService userStatusService,
            ITextSpanFactory textSpanFactory)
        {
            _roomService = roomService;
            _userStatusService = userStatusService;
            _textSpanFactory = textSpanFactory;
        }

        async Task NavigateToRoom(string roomId, IGameContentManager contentManager)
        {
            var room = await _roomService.GetRoomByIdAsync(roomId);

            await _userStatusService.SetCurrentRoomIdAsync(room.Id);

            var content = _textSpanFactory.MapTextSpanToXamarinSpan(room.Content.content);

            contentManager.BindContentText(content);
        }

        public async Task ExecuteRoomActionAsync(RoomActionVm action, IGameContentManager contentManager)
        {
            if (action.RoomActionType == ActionTypeEnum.Navigation)
            {
                await NavigateToRoom(action.RoomToNavigateId, contentManager);
            }
        }
    }
}
