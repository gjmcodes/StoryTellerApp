using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Interfaces.Repositories.Users;
using StoryTeller.Core.Interfaces.Services.Users;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.Users
{
    public class UserStatusService : BaseService, IUserStatusService
    {
        private readonly IUserLocalRepository _userStatusLocalRepository;
        private readonly IUserCharacterRepository _userCharacterRepository;

        public UserStatusService(IUserLocalRepository userStatusLocalRepository,
            IUserCharacterRepository userCharacterRepository)
        {
            _userStatusLocalRepository = userStatusLocalRepository;
            _userCharacterRepository = userCharacterRepository;
        }

        public async Task UpdateCurrentPageIdAsync(string pageId)
        {
            await _userStatusLocalRepository.UpdateUserCurrentPageAsync(pageId);
        }

        public async Task<string> GetCurrentPageIdAsync()
        {
            var currentPage =  await _userCharacterRepository.GetCharacterCurrentPageAsync();
            if (string.IsNullOrEmpty(currentPage))
                return "page-1";

            return currentPage;
        }

        protected override void ReleaseResources()
        {
            _userCharacterRepository.Dispose();
            _userStatusLocalRepository.Dispose();
        }
    }
}
