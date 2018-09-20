using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Interfaces.Repositories.Local;
using StoryTeller.Core.Interfaces.Services.Rooms;
using StoryTeller.Core.Rooms;

namespace StoryTeller.Core.Services.Rooms
{
    public class RoomContentService :BaseService, IRoomContentService
    {
        private readonly IRoomContentLocalRepository _roomContentLocalRepository;
        private readonly IRoomContentExternalRepository _roomContentExternalRepository;

        public RoomContentService(IRoomContentExternalRepository roomContentExternalRepository)
        {
            _roomContentExternalRepository = roomContentExternalRepository;
        }

        public async Task CreateRoomContentAsync(IEnumerable<RoomContent> roomContents, string culture)
        {
            await _roomContentExternalRepository.CreateRoomContentsAsync(roomContents, culture);
        }

        public async Task<RoomContent> GetRoomContentByIdAsync(string roomId, string contentId)
        {
            //var roomContent = await _roomContentLocalRepository.GetRoomContentByIdAsync(contentId);
            //if (roomContent.content?.Count() > 0)
            //    return roomContent;

            var roomContent = await _roomContentExternalRepository.GetRoomContentByIdAsync(roomId, contentId);

            return roomContent;
        }

        public async Task<RoomContent> GetRoomDefaultContentAsync(string roomId)
        {
            //var roomContent = await _roomContentExternalRepository.GetRoomDefaultContentAsync(roomId);

            //if (roomContent.Content?.Count() > 0)
            //    return roomContent;

            var roomContent = await _roomContentExternalRepository.GetRoomDefaultContentAsync(roomId);

            return roomContent;
        }
    }
}
