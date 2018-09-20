using StoryTeller.Core.Interfaces.Repositories.Rooms;
using StoryTeller.Core.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.External
{
    public interface IRoomActionExternalRepository : IRoomActionRepository
    {
        Task CreateRoomActionsAsync(IEnumerable<RoomAction> roomActions, string culture);
    }
}
