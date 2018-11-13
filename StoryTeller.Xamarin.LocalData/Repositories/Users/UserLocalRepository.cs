using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Xamarin.Domain.Entities.App;
using System;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.LocalData.Repositories.Users
{
    public class UserLocalRepository : BaseRepository, IUserLocalRepository
    {
        async Task<XamarinUserSettings> GetUserSettingsAsync()
        {
            var userSettings = await Conn.Table<XamarinUserSettings>().FirstOrDefaultAsync();

            return userSettings;
        }


        public async Task<string> GetSelectedCultureAsync()
        {
            var userSettings = await GetUserSettingsAsync();

            return userSettings.SelectedCulture;
        }

        public Task<bool> HasSelectedCultureAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SetSelectedCultureAsync(string selectedCulture)
        {
            var userSettings = await GetUserSettingsAsync();

            if (userSettings == null)
            {
                userSettings = new XamarinUserSettings()
                {
                    SelectedCulture = selectedCulture
                };

                return await Conn.InsertAsync(userSettings) > 0;
            }

            userSettings.SelectedCulture = selectedCulture;

            return await Conn.UpdateAsync(userSettings) > 0;
        }

        public Task<bool> UpdateUserCurrentPageAsync(string pageId)
        {
            throw new NotImplementedException();
        }
    }
}
