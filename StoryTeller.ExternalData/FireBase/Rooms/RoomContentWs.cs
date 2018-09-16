using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Rooms;
using StoryTeller.CrossCutting.User.Preferences;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.Rooms
{
    public class RoomContentWs : BaseFirebaseWs, IRoomContentExternalRepository
    {
        public RoomContentWs(UserPreferences userPreferences) 
            : base("RoomContent", userPreferences)
        {
        }

        public async Task<RoomContent> GetRoomContentByIdAsync(string roomId, string roomContentId)
        {
            var data = await base.GetByFieldWithLanguageAsync<RoomContent>(nameof(roomId), roomId, "id", roomContentId);

            return data.FirstOrDefault();
        }

        public async Task<RoomContent> GetRoomDefaultContentAsync(string roomId)
        {
            var data = await base.GetByKeyWithLanguageAsync<RoomContent>(nameof(roomId), roomId);

            return data.FirstOrDefault();
        }

        protected override void ReleaseResources()
        {
        }
    }
}
