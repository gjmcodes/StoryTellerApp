using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.Users
{
    public interface IUserLocalRepository : IBaseRepository
    {
        Task<bool> UpdateUserCurrentPageAsync(string pageId);
        Task<bool> SetSelectedCultureAsync(string selectedCulture);
        Task<bool> HasSelectedCultureAsync();
        Task<string> GetCurrentPageAsync();
        Task<string> GetSelectedCultureAsync();
    }
}
