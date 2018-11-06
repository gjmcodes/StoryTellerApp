using StoryTeller.Core.Models.App;
using StoryTeller.InternalData.DTOs.PersistentObjects.App;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Interfaces.Factories.App
{
    public interface IAppDictionaryFactory : IBaseLocalDataFactory
    {
        Task<AppDictionaryDto> MapAppDictionaryToDto(AppDictionary appDictionary);
        Task<AppDictionary> MapDtoToAppDictionaryAsync(AppDictionaryDto dto);

    }
}
