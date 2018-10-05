using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.Users
{
    public interface IUserStatusService : IBaseService
    {
        Task UpdateCurrentPageIdAsync(string pageId);
        Task<string> GetCurrentPageIdAsync();
    }
}
