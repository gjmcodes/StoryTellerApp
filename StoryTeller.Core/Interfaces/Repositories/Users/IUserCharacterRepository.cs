using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Users
{
    public interface IUserCharacterRepository : IBaseRepository
    {
        Task<string> GetCharacterCurrentPageAsync();
    }
}
