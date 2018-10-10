using Firebase.Database;
using Firebase.Database.Query;
using StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.Users;
using StoryTeller.CrossCutting.Disposable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase
{
    public abstract class BaseFirebaseWs : DisposableObject
    {
        protected string baseDatabaseUrl = "https://storyteller-92a39.firebaseio.com";
        protected FirebaseClient _fireBaseClient;
        protected string collection;

        private readonly IUserStatusLocalRepository _userStatusLocalRepository;

        public BaseFirebaseWs(string collection, IUserStatusLocalRepository userStatusLocalRepository)
        {
            _userStatusLocalRepository = userStatusLocalRepository;


            this.collection = collection;
            _fireBaseClient = new FirebaseClient(baseDatabaseUrl);
        }

        async Task<ChildQuery> QueryableCollectionWithLanguageAsync()
        {
            var userCulture = await _userStatusLocalRepository.GetUserCurrentPageAsync();
            return _fireBaseClient
            .Child(collection)
            .Child(userCulture);
        }

        protected async Task<IEnumerable<T>> GetByFieldWithLanguageAsync<T>(string keyName, string keyValue, string fieldName, string fieldValue)
        {
            var objects = new List<T>();

            var langQuery = await QueryableCollectionWithLanguageAsync();
            var request = await langQuery
                .OrderBy(keyName)
                .EqualTo(keyValue)
                .OnceAsync<T>();

            var objType = request.Select(x => x.Object).FirstOrDefault()?.GetType();

            var filteredResult = request.Select(x => x.Object).Where(x =>
            x.GetType()
            .GetField(fieldName)
            .GetValue(x).ToString()
            .Equals(fieldValue));

            foreach (var item in filteredResult)
            {
                objects.Add(item);
            }

            return objects;
        }

        protected async Task<IEnumerable<T>> GetByKeyWithLanguageAsync<T>(string keyName, string keyValue)
        {
            try
            {


                var objects = new List<T>();


                var langQuery = await QueryableCollectionWithLanguageAsync();
                var request = await langQuery
                    .OrderBy(keyName)
                    .EqualTo(keyValue)
                    .OnceAsync<T>();

            

                foreach (var item in request)
                {
                    objects.Add(item.Object);
                }

                return objects;
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }

        protected async Task<IEnumerable<T>> GetByKeyAsync<T>(string keyName, string keyValue)
        {
            var objects = new List<T>();

            var request = await _fireBaseClient
                .Child(collection)
                .OrderBy(keyName)
                .EqualTo(keyValue)
                .OnceAsync<T>();

            foreach (var item in request)
            {
                objects.Add(item.Object);
            }

            return objects;
        }

        protected async Task CreateAsync<T>(T model, string culture)
        {
            var url = baseDatabaseUrl + $"/{culture}";

            var obj = await _fireBaseClient
                .Child(collection)
                .Child(culture)
                .PostAsync<T>(model);
        }
    }
}
