using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Users
{
    public interface IUserStatusLocalPersistentRepository : IBaseRepository
    {
        Task<bool> UpdateUserCurrentPageAsync(string pageId);
        Task<bool> SetSelectedCultureAsync(string selectedCulture);
        Task<bool> HasSelectedCultureAsync();
    }
}
