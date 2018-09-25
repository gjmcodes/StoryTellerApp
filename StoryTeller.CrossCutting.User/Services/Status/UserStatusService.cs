using StoryTeller.CrossCutting.User.Interfaces.Services;
using System.Threading.Tasks;

namespace StoryTeller.CrossCutting.User.Services.Status
{
    public class UserStatusService : BaseService, IUserStatusService
    {
        string currentRoomId;

        public async Task SetCurrentPageIdAsync(string roomId)
        {
            this.currentRoomId = roomId;
        }

        public async Task<string> GetCurrentPageIdAsync()
        {
            return string.IsNullOrEmpty(this.currentRoomId) ? "page-1" : this.currentRoomId;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
