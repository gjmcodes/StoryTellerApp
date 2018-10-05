using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Users
{
    public interface IUserStatusServicePersistentRepository : IBaseRepository
    {
        Task<bool> UpdateUserCurrentPageAsync(string pageId);
    }
}
