using StoryTeller.Core.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.Rooms
{
    public interface IRoomEventService : IBaseService
    {
        Task<IEnumerable<RoomEvent>> GetRoomEventsAsync(string roomId);
    }
}
