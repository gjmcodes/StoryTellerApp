using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Interfaces.Services.Users;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.Users
{
    public class UserStatusService : BaseService, IUserStatusService
    {
        private readonly IUserStatusLocalRepository _userStatusLocalRepository;

        public UserStatusService(IUserStatusLocalRepository userStatusLocalRepository)
        {
            _userStatusLocalRepository = userStatusLocalRepository;
        }

        public async Task UpdateCurrentPageIdAsync(string pageId)
        {
            await _userStatusLocalRepository.UpdateUserCurrentPageAsync(pageId);
        }

        public async Task<string> GetCurrentPageIdAsync()
        {
            var currentPage = await _userStatusLocalRepository.GetCurrentPageAsync();
            if (string.IsNullOrEmpty(currentPage))
                return "page-1";

            return currentPage;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
