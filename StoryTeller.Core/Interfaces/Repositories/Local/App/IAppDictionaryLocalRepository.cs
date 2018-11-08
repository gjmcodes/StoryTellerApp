using StoryTeller.Core.Models.App;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.App
{
    public interface IAppDictionaryLocalRepository : IBaseRepository
    {
        Task<AppDictionary> GetAppDictionaryAsync();
        Task<bool> UpdateAppDictionaryAsync(AppDictionary appDictionary);
    }
}
