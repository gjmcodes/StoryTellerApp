using StoryTeller.Core.Rooms;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.Rooms
{
    public interface IRoomService
    {
        Task<Room> GetRoomByIdAsync(string roomId);
    }
}
