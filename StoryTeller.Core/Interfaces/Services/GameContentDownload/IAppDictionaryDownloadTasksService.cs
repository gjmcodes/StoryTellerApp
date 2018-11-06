using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.GameContentDownload
{
    public interface IAppDictionaryDownloadTasksService : IBaseService
    {
        Task<bool> DownloadAppDictionaryByCultureAsync();
    }
}
