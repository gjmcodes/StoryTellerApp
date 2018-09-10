using StoryTeller.Core.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Rooms
{
    public interface IRoomActionRepository
    {
        Task<IEnumerable<RoomAction>> GetRoomActionsAsync(string roomId);
    }
}
