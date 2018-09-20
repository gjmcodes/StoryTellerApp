using StoryTeller.Core.Interfaces.Repositories.Rooms;
using StoryTeller.Core.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.External
{
    public interface IRoomContentExternalRepository : IRoomContentRepository
    {
        Task CreateRoomContentsAsync(IEnumerable<RoomContent> roomContents, string culture);
    }
}
