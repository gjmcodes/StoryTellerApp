using StoryTeller.Core.Rooms;
using StoryTeller.Core.Rooms.Aggregates;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.Rooms
{
    public interface IRoomService : IBaseService
    {
        Task<Room> GetRoomByIdAsync(string roomId);
        Task CreateRoomAsync(RoomCreationAggregate roomCreationAggregate, string culture);
    }
}
