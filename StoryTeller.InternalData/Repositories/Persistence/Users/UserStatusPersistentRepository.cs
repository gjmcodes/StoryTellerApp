using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Users;
using StoryTeller.InternalData.DTOs.PersistentObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Repositories.Persistence.Users
{
    public class UserStatusPersistentRepository : BaseRepository, IUserStatusLocalPersistentRepository
    {
        async Task<UserStatusDto> GetUserStatusAsync()
        {
            var query = await base.Conn.QueryAsync<UserStatusDto>("select * from");
            var user = query.FirstOrDefault();

            if(user == null)
            {
                user = new UserStatusDto();
                await base.AddAsync<UserStatusDto>(user);
            }

            return user;
        }

        public async Task<bool> SetSelectedCultureAsync(string selectedCulture)
        {
            var dto = new UserStatusDto() { SelectedCulture = selectedCulture};

            return await base.AddAsync<UserStatusDto>(dto);
        }

        public async Task<bool> UpdateUserCurrentPageAsync(string pageId)
        {
            var dto = new UserStatusDto() { CurrentPageId = pageId };

            return await base.AddAsync<UserStatusDto>(dto);
        }

        public async Task<bool> HasSelectedCultureAsync()
        {
            var user = await GetUserStatusAsync();

            return !string.IsNullOrEmpty(user.SelectedCulture);
        }
    }
}
