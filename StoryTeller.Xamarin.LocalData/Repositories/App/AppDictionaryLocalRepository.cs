using StoryTeller.Core.Interfaces.Repositories.External.App;
using StoryTeller.Core.Models.App;
using StoryTeller.Xamarin.Domain.Entities.App;
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
        private readonly IAppUpdateExternalRepository _appUpdateExternalRepository;

        public AppDictionaryLocalRepository(IXamarinAppDictionaryFactory xamarinAppDictionaryFactory,
            IAppUpdateExternalRepository appUpdateExternalRepository)
        {
            _xamarinAppDictionaryFactory = xamarinAppDictionaryFactory;
            _appUpdateExternalRepository = appUpdateExternalRepository;
        }

        public async Task<bool> AddAppDictionaryAsync(AppDictionary appDictionary)
        {
            var version = await _appUpdateExternalRepository.GetAppDictionaryCurrentVersionByCultureAsync();

            var xamAppDic = await _xamarinAppDictionaryFactory.MapAppDictionaryToXamarin(appDictionary, version.version);

            await Conn.InsertAsync(xamAppDic);

            return true;
        }

        public async Task<XamarinAppDictionary> GetAppDictionaryAsync()
        {
            var xamAppDic = await Conn.Table<XamarinAppDictionary>().FirstAsync();

            return xamAppDic;
        }

        public async Task<int> GetVersionAsync()
        {
            var xamAppDic = await Conn.Table<XamarinAppDictionary>().FirstAsync();

            return xamAppDic.ExternalTableVersion;
        }

        protected override void ReleaseResources()
        {
            _xamarinAppDictionaryFactory.Dispose();
            _appUpdateExternalRepository.Dispose();
            base.ReleaseResources();
        }
    }
}
