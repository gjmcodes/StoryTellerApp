using StoryTeller.CrossCutting.User.Interfaces.Services;
using System.Threading.Tasks;

namespace StoryTeller.CrossCutting.User.Services.Status
{
    public class UserStatusService : BaseService, IUserStatusService
    {
        string currentRoomId;

        public async Task SetCurrentRoomIdAsync(string roomId)
        {
            this.currentRoomId = roomId;
        }

        public async Task<string> GetCurrentRoomIdAsync()
        {
            return string.IsNullOrEmpty(this.currentRoomId) ? "room-1" : this.currentRoomId;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
