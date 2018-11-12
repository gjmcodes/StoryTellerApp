using StoryTeller.Core.Interfaces.Repositories.External.App;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Models.App;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.App
{
    public class AppDictionaryWs : BaseFirebaseWs, IAppDictionaryExternalRepository
    {
        public AppDictionaryWs(IUserLocalRepository userStatusLocalRepository) 
            : base("AppDictionary", userStatusLocalRepository)
        {
        }

        public async Task<AppDictionary> GetAppDictionaryByCultureAsync()
        {
            var langQuery = await base.QueryableCollectionWithLanguageAsync();

            var data = await langQuery.OnceSingleAsync<AppDictionary>();

            return data;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
