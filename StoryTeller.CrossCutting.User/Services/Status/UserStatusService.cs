using StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.Users;
using StoryTeller.CrossCutting.User.Interfaces.Services;
using System.Threading.Tasks;

namespace StoryTeller.CrossCutting.User.Services.Status
{
    public class UserStatusService : BaseService, IUserStatusService
    {
        private readonly IUserStatusLocalRepository _userStatusLocalRepository;

        string currentRoomId;

        public async Task SetCurrentPageIdAsync(string roomId)
        {
            this.currentRoomId = roomId;
        }

        public async Task<string> GetCurrentPageIdAsync()
        {
            return string.IsNullOrEmpty(this.currentRoomId) ? "intro" : this.currentRoomId;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
