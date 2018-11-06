using StoryTeller.Core.Models.App;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.App
{
    public interface IAppDictionaryLocalRepository : IBaseRepository
    {
        Task<AppDictionary> GetAppDictionary();
        Task<bool> UpdateAppDictionaryAsync(AppDictionary appDictionary);
    }
}
