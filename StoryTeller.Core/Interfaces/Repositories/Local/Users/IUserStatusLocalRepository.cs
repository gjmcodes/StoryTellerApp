using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.Users
{
    public interface IUserStatusLocalRepository : IBaseRepository
    {
        Task<bool> UpdateUserCurrentPageAsync(string pageId);
        Task<bool> SetSelectedCultureAsync(string selectedCulture);
        Task<bool> HasSelectedCultureAsync();
    }
}
