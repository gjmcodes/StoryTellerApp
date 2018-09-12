using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Rooms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.Rooms
{
    public class RoomEventWs : BaseFirebaseWs, IRoomEventExternalRepository
    {
        public RoomEventWs() 
            : base("RoomEvents")
        {
        }

        public async Task<IEnumerable<RoomEvent>> GetRoomEventsAsync(string roomId)
        {
            return await base.GetByKey<RoomEvent>(nameof(roomId), roomId);
        }

        protected override void ReleaseResources()
        {
        }

    }
}
