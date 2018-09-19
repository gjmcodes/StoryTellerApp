using System.Linq;
using System.Threading.Tasks;
using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Interfaces.Repositories.Rooms;
using StoryTeller.Core.Rooms;
using StoryTeller.CrossCutting.User.Preferences;

namespace StoryTeller.ExternalData.FireBase.Rooms
{
    public class RoomWs : BaseFirebaseWs, IRoomExternalRepository, IRoomRepository
    {
        public RoomWs(UserPreferences userPreferences) 
            : base("Rooms", userPreferences)
        {
        }

        public async Task CreateRoomAsync(Room room, string culture)
        {
            await base.CreateAsync<Room>(room, culture);
        }

        public async Task<Room> GetRoomByIdAsync(string roomId)
        {
            var data = await base.GetByKeyWithLanguageAsync<Room>(nameof(roomId), roomId);

            return data.FirstOrDefault();
        }

        protected override void ReleaseResources()
        {
        }
    }
}
