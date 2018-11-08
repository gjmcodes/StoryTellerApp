using System.Threading.Tasks;
using StoryTeller.Core.Interfaces.Repositories.Local.App;
using StoryTeller.Core.Models.App;
using StoryTeller.InternalData.DTOs.PersistentObjects.App;
using StoryTeller.InternalData.Interfaces.Factories.App;

namespace StoryTeller.InternalData.Repositories.App
{
    public class AppDictionaryRepository : BaseRepository, IAppDictionaryLocalRepository
    {
        private readonly IAppDictionaryFactory _appDictionaryFactory;

        public AppDictionaryRepository(IAppDictionaryFactory appDictionaryFactory)
        {
            _appDictionaryFactory = appDictionaryFactory;
        }

        public async Task<AppDictionary> GetAppDictionaryAsync()
        {
            var dto = await base.Conn.Table<AppDictionaryDto>().FirstAsync();

            var data = await _appDictionaryFactory.MapDtoToAppDictionaryAsync(dto);

            return data;
        }

        public async Task<bool> UpdateAppDictionaryAsync(AppDictionary appDictionary)
        {
            var dto = await _appDictionaryFactory.MapAppDictionaryToDto(appDictionary);

            return await base.AddAsync(dto);
        }
    }
}
