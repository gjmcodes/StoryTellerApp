using System.Threading.Tasks;

namespace StoryTeller.CrossCutting.User.Interfaces.Services
{
    public interface IUserStatusService : IBaseService
    {
        Task SetCurrentPageId(string roomId);
        Task<string> GetCurrentPageIdAsync();
    }
}
