using StoryTeller.Core.Rooms;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Rooms
{
    public interface IRoomContentRepository
    {
        Task<RoomContent> GetRoomContentByIdAsync(string roomId, string roomContentId);
        Task<RoomContent> GetRoomDefaultContentAsync(string roomId);
    }
}
