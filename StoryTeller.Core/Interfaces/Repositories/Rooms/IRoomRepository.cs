using StoryTeller.Core.Rooms;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Rooms
{
    public interface IRoomRepository
    {
        Task<Room> GetRoomByIdAsync(string roomId);
        Task CreateRoomAsync(Room room, string culture);
    }
}
