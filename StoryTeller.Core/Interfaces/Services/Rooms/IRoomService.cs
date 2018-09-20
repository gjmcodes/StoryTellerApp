using StoryTeller.Core.Rooms;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.Rooms
{
    public interface IRoomService : IBaseService
    {
        Task<Room> GetRoomByIdAsync(string roomId);
        Task CreateRoomAsync(Room room, string culture);
    }
}
