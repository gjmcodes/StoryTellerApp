using Firebase.Database.Query;
using StoryTeller.Core.Interfaces.Repositories.External.App;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Models.App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.App
{
    public class AppUpdateWs : BaseFirebaseWs, IAppUpdateExternalRepository
    {
        public AppUpdateWs(IUserLocalRepository userStatusLocalRepository)
            : base("AppUpdates", userStatusLocalRepository)
        {
        }

        async Task<ChildQuery> QueryableCollectionWithLanguageAsync(string childCollection)
        {
            var language = await _userStatusLocalRepository.GetSelectedCultureAsync();
            var langQuery =  base._fireBaseClient
                .Child(collection)
                .Child(childCollection)
                .Child(language);

            return langQuery;
        }
        public async Task<AppUpdate> GetAppDictionaryCurrentVersionByCultureAsync()
        {
            var langQuery = await QueryableCollectionWithLanguageAsync("AppDictionary");

            return await langQuery.OnceSingleAsync<AppUpdate>();
        }

        public async Task<AppUpdate> GetPagesCurrentVersionByCultureAsync()
        {
            var langQuery = await QueryableCollectionWithLanguageAsync("Pages");

            return await langQuery.OnceSingleAsync<AppUpdate>();
        }

        public async Task<AppUpdate> GetPronoumCurrentVersionByCultureAsync()
        {
            var langQuery = await QueryableCollectionWithLanguageAsync("Pronoums");

            return await langQuery.OnceSingleAsync<AppUpdate>();
        }

        protected override void ReleaseResources()
        {
        }
    }
}
