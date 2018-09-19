using StoryCreator.Web.Models.Results;
using StoryCreator.Web.Models.Rooms.Create;
using StoryTeller.CrossCutting.Disposable;
using System.Threading.Tasks;

namespace StoryCreator.Web.Interfaces.Services.Rooms
{
    public interface IRoomAppService : IDisposableObject
    {
        Task<OperationResult> CreateRoomAsync(CreateRoomVm roomVm);
    }
}
