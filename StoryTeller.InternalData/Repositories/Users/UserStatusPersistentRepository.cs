using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.InternalData.DTOs.PersistentObjects.Users;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Repositories.Users
{
    public class UserStatusPersistentRepository : BaseRepository, IUserStatusLocalRepository
    {
        async Task<UserStatusDto> GetUserStatusAsync()
        {
            var user = await base.Conn.Table<UserStatusDto>().FirstOrDefaultAsync();

            if(user == null)
            {
                user = new UserStatusDto();
                await base.AddAsync<UserStatusDto>(user);
            }

            return user;
        }

        public async Task<bool> SetSelectedCultureAsync(string selectedCulture)
        {
            var dto = await GetUserStatusAsync();
            dto.SelectedCulture = selectedCulture;

            return await base.UpdateAsync<UserStatusDto>(dto);
        }

        public async Task<bool> UpdateUserCurrentPageAsync(string pageId)
        {
            var dto = await GetUserStatusAsync();
            dto.CurrentPageId = pageId;

            return await base.AddAsync<UserStatusDto>(dto);
        }

        public async Task<bool> HasSelectedCultureAsync()
        {
            var user = await GetUserStatusAsync();

            return !string.IsNullOrEmpty(user.SelectedCulture);
        }

        public async Task<string> GetCurrentPageAsync()
        {
            var user = await GetUserStatusAsync();

            return user.CurrentPageId;
        }

        public async Task<string> GetSelectedCultureAsync()
        {
            var user = await GetUserStatusAsync();

            return user.SelectedCulture;
        }
    }
}
