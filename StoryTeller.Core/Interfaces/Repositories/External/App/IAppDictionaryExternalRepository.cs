using StoryTeller.Core.Models.App;
using StoryTeller.CrossCutting.Disposable;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.External.App
{
    public interface IAppDictionaryExternalRepository : IDisposableObject
    {
        Task<AppDictionary> GetAppDictionaryByCultureAsync();
    }
}
