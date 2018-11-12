using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using System;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.LocalData.Repositories.Users
{
    public class UserLocalRepository : BaseRepository, IUserLocalRepository
    {
        public Task<string> GetCurrentPageAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSelectedCultureAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasSelectedCultureAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetSelectedCultureAsync(string selectedCulture)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserCurrentPageAsync(string pageId)
        {
            throw new NotImplementedException();
        }
    }
}
