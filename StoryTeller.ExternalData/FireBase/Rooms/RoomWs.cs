using System.Linq;
using System.Threading.Tasks;
using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Rooms;

namespace StoryTeller.ExternalData.FireBase.Rooms
{
    public class RoomWs : BaseFirebaseWs, IRoomExternalRepository
    {
        public RoomWs() 
            : base("Rooms")
        {
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
