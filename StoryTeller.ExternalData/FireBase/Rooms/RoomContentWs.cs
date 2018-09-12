using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.Rooms
{
    public class RoomContentWs : BaseFirebaseWs, IRoomContentExternalRepository
    {
        public RoomContentWs() 
            : base("RoomContent")
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
