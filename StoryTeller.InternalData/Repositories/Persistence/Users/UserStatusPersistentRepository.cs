using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Users;
using StoryTeller.InternalData.DTOs.PersistentObjects.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Repositories.Persistence.Users
{
    public class UserStatusPersistentRepository : BaseRepository, IUserStatusLocalPersistentRepository
    {
        public async Task<bool> UpdateUserCurrentPageAsync(string pageId)
        {
            var dto = new UserStatusDto(pageId);
            return await base.AddAsync<UserStatusDto>(dto);
        }

    }
}
