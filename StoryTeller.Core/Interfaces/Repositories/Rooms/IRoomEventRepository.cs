using StoryTeller.Core.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Rooms
{
    public interface IRoomEventRepository
    {
        Task<IEnumerable<RoomEvent>> GetRoomEventsAsync(string roomId);
    }
}
