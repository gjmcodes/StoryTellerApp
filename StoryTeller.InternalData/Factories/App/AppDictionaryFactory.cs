using StoryTeller.Core.Models.App;
using StoryTeller.InternalData.DTOs.PersistentObjects.App;
using StoryTeller.InternalData.Interfaces.Factories.App;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Factories.App
{
    public class AppDictionaryFactory : BaseLocalDataFactory, IAppDictionaryFactory
    {
        public async Task<AppDictionaryDto> MapAppDictionaryToDto(AppDictionary appDictionary)
        {
            return await Task.Run(() =>
            {
                var dto = new AppDictionaryDto();
                dto.Exit = appDictionary.exit;
                dto.Male = appDictionary.male;
                dto.Female = appDictionary.female;
                dto.Languages = appDictionary.languages;
                dto.NamePlaceholder = appDictionary.namePlaceholder;

                return dto;
            });
        }

        public async Task<AppDictionary> MapDtoToAppDictionaryAsync(AppDictionaryDto dto)
        {
            return await Task.Run(() =>
            {
                var obj = new AppDictionary();
                obj.namePlaceholder = dto.NamePlaceholder;
                obj.languages = dto.Languages;
                obj.male = dto.Male;
                obj.female= dto.Female;
                obj.exit = dto.Exit;

                return obj;
            });
        }

        protected override void ReleaseResources()
        {
        }
    }
}
