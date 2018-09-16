using StoryTellerTemplate.Models.MainPage;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.Services.GameContent
{
    public interface IGameContentAppService : IBaseAppService
    {
        Task<RoomVm> GetCurrentRoomDataAsync();
        Task<RoomVm> GetRoomDataAsync(string roomId);
    }
}
