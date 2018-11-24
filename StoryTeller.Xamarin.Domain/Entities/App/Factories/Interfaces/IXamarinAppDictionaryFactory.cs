using StoryTeller.Core.Disposing;
using StoryTeller.Core.Models.App;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.App.Factories.Interfaces
{
    public interface IXamarinAppDictionaryFactory : IDisposableObject
    {
        Task<XamarinAppDictionary> MapAppDictionaryToXamarin(AppDictionary appDictionary, int dictionaryVersion);
    }
}
