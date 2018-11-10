using StoryTeller.Core.Models.App;
using StoryTeller.Xamarin.Domain.Entities.App.Factories.Interfaces;
using StoryTeller.Xamarin.Domain.Entities.App.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.LocalData.Repositories.App
{
    public class AppDictionaryLocalRepository : BaseRepository, IAppDictionaryLocalRepository
    {
        private readonly IXamarinAppDictionaryFactory _xamarinAppDictionaryFactory;

        public AppDictionaryLocalRepository(IXamarinAppDictionaryFactory xamarinAppDictionaryFactory)
        {
            _xamarinAppDictionaryFactory = xamarinAppDictionaryFactory;
        }

        public async Task<bool> AddAppDictionaryAsync(AppDictionary appDictionary)
        {
            var xamAppDic = await _xamarinAppDictionaryFactory.MapAppDictionaryToXamarin(appDictionary);

            await Conn.InsertAsync(xamAppDic);

            return true;
        }

        protected override void ReleaseResources()
        {
            _xamarinAppDictionaryFactory.Dispose();
        }
    }
}
