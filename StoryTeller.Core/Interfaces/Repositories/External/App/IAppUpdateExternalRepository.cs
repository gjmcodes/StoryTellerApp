using StoryTeller.Core.Disposing;
using StoryTeller.Core.Models.App;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.External.App
{
    public interface IAppUpdateExternalRepository : IDisposableObject
    {
        Task<AppUpdate> GetAppDictionaryCurrentVersionByCultureAsync();
        Task<AppUpdate> GetPagesCurrentVersionByCultureAsync();
        Task<AppUpdate> GetPronoumCurrentVersionByCultureAsync();
    }
}
