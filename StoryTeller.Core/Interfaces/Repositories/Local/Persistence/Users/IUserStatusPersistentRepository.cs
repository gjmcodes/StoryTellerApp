using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Users
{
    public interface IUserStatusPersistentRepository : IBaseRepository
    {
        Task<bool> UpdateUserCurrentPageAsync(string pageId);
    }
}
