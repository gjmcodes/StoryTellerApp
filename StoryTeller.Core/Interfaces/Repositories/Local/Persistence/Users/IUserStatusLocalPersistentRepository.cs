using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Users
{
    public interface IUserStatusLocalPersistentRepository : IBaseRepository
    {
        Task<bool> UpdateUserCurrentPageAsync(string pageId);
    }
}
