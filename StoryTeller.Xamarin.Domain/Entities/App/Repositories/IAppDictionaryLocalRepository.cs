using StoryTeller.Core.Interfaces.Repositories;
using StoryTeller.Core.Models.App;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.App.Repositories
{
    public interface IAppDictionaryLocalRepository : IBaseRepository
    {
        Task<bool> AddAppDictionaryAsync(AppDictionary appDictionary);
        Task<XamarinAppDictionary> GetAppDictionaryAsync();
        Task<int> GetVersionAsync();
    }
}
