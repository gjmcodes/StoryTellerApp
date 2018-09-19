using StoryTeller.Core.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.Rooms
{
    public interface IRoomContentService : IBaseService
    {
        Task<RoomContent> GetRoomContentByIdAsync(string roomId, string contentId);
        Task<RoomContent> GetRoomDefaultContentAsync(string roomId);
        Task CreateRoomContentAsync(IEnumerable<RoomContent> roomContents, string culture);
            
    }
}
