using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.Users
{
    public interface IUserStatusLocalRepository : IBaseRepository
    {
        Task<string> GetUserCurrentPageAsync();
    }
}
