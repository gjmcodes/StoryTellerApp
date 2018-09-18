using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.Models.RoomActions;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.Services.RoomActions
{
    public interface IRoomActionAppService : IBaseAppService
    {
        Task ExecuteRoomActionAsync(RoomActionVm roomAction, IGameContentManager gameContentManager);
    }
}
