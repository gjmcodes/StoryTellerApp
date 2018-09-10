using StoryTeller.Core.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.Rooms
{
    public interface IRoomEventService
    {
        Task<IEnumerable<RoomEvent>> GetRoomEventsAsync(string roomId);
    }
}
