using StoryTellerTemplate.Interfaces.ViewModels;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.Services.GameContent
{
    public interface IGameContentDownloadAppService : IBaseAppService
    {
        Task<bool> DownloadGameContentForCultureAsync(IContentDownloader contentDownloader);
    }
}
