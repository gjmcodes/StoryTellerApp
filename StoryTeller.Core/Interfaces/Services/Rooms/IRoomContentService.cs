using StoryTeller.Core.Rooms;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.Rooms
{
    public interface IRoomContentService
    {
        Task<RoomContent> GetRoomContentByIdAsync(string contentId);
        Task<RoomContent> GetRoomDefaultContentAsync(string roomId);
    }
}
