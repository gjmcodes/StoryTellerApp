using StoryTellerTemplate.Interfaces.Services;
using StoryTellerTemplate.Models.GameContent;
using StoryTellerTemplate.Services.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Services.GameContent
{
    public class GameContentAppService
    {
        GameContextVm ctxMock;
        RoomVm roomMock;

        private readonly IPaginationAppService _paginationAppService;

        public GameContentAppService()
        {
            _paginationAppService = new PaginationAppService();

            ctxMock = new GameContextVm();
            roomMock = new RoomVm();

            var actionsMock = new List<RoomActionVm>()
            {
                new RoomActionVm(){Name="Observar ao redor"},
                new RoomActionVm(){Name="Gritar por socorro"},
            };

            roomMock.Actions = actionsMock;
            ctxMock.Room = roomMock;
        }

        public async Task<GameContextVm> GetCurrentGameContextAsync(string roomId, int chapter)
        {
            var text = await _paginationAppService.GetCurrentPageContentTextSpansAsync();
            ctxMock.Room.Content = text;

            return ctxMock;
        }
    }
}
