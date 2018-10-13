using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Users;
using StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.Users;
using StoryTeller.Core.Interfaces.Services.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.Users
{
    public class UserStatusService : BaseService, IUserStatusService
    {
        private readonly IUserStatusLocalReadOnlyRepository _userStatusLocalRepository;
        private readonly IUserStatusLocalRepository _userStatusServicePersistentRepository;

        public async Task UpdateCurrentPageIdAsync(string pageId)
        {
            await _userStatusServicePersistentRepository.UpdateUserCurrentPageAsync(pageId);
        }

        public async Task<string> GetCurrentPageIdAsync()
        {
            var currentPage = await _userStatusLocalRepository.GetUserCurrentPageAsync();
            if (string.IsNullOrEmpty(currentPage))
                return "intro";

            return currentPage;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
