using System.Threading.Tasks;

namespace StoryTeller.CrossCutting.User.Interfaces.Services
{
    public interface IUserStatusService : IBaseService
    {
        Task SetCurrentRoomIdAsync(string roomId);
        Task<string> GetCurrentRoomIdAsync();
    }
}
