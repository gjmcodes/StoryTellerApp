using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database.Query;
using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Rooms;
using StoryTeller.CrossCutting.User.Preferences;

namespace StoryTeller.ExternalData.FireBase.Rooms
{
    public class RoomActionWs : BaseFirebaseWs, IRoomActionExternalRepository
    {
        public RoomActionWs(UserPreferences userPreferences)
            : base("RoomActions", userPreferences)
        {
        }

        public async Task<IEnumerable<RoomAction>> GetRoomActionsAsync(string roomId)
        {
            return await base.GetByKeyWithLanguageAsync<RoomAction>(nameof(roomId), roomId);
            //var actions = new List<RoomAction>();

            //var request = await _fireBaseClient
            //    .Child(collection)
            //    .OrderBy("roomId")
            //    .EqualTo(roomId)
            //    .OnceAsync<RoomAction>();

            //foreach (var item in request)
            //{
            //    actions.Add(item.Object);
            //}

            //return actions;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
