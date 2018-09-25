using StoryTellerTemplate.Models.MainPage;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.Services.GameContent
{
    public interface IGameContentAppService : IBaseAppService
    {
        Task<PageVm> GetCurrentPageAsync();
        Task<PageVm> GetPageByIdAsync(string roomId);
    }
}
