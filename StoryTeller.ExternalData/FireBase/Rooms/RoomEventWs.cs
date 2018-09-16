using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Rooms;
using StoryTeller.CrossCutting.User.Preferences;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.Rooms
{
    public class RoomEventWs : BaseFirebaseWs, IRoomEventExternalRepository
    {
        public RoomEventWs(UserPreferences userPreferences) 
            : base("RoomEvents", userPreferences)
        {
        }

        public async Task<IEnumerable<RoomEvent>> GetRoomEventsAsync(string roomId)
        {
            return await base.GetByKeyAsync<RoomEvent>(nameof(roomId), roomId);
        }

        protected override void ReleaseResources()
        {
        }

    }
}
