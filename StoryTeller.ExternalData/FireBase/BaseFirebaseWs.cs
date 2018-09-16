using Firebase.Database;
using Firebase.Database.Query;
using StoryTeller.CrossCutting.Disposable;
using StoryTeller.CrossCutting.User.Preferences;
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
        protected UserPreferences _userPreferences;

        ChildQuery QueryableCollectionWithLanguage => _fireBaseClient
            .Child(collection)
            .Child(_userPreferences.CurrentLanguage);

        public BaseFirebaseWs(string collection, UserPreferences userPreferences)
        {
            _userPreferences = userPreferences;

            this.collection = collection;
            _fireBaseClient = new FirebaseClient(baseDatabaseUrl);
        }

        protected async Task<IEnumerable<T>> GetByFieldWithLanguageAsync<T>(string keyName, string keyValue, string fieldName, string fieldValue)
        {
            var objects = new List<T>();

            var request = await QueryableCollectionWithLanguage
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

                //using (var http = new HttpClient())
                //using (var request = new HttpRequestMessage(HttpMethod.Get,
                //    new Uri($"{baseDatabaseUrl}/{collection}/.json?orderBy=\"{keyName}\"&equalTo=\"{keyValue}\"")))
                //{
                //    var data = await http.SendAsync(request);

                //    var content = await data.Content.ReadAsJsonAsync<Dictionary<string, T>>();
                //    return content.Select(x => x.Value).ToArray();
                //}
                var request = await _fireBaseClient
                .Child(collection)
                .Child(_userPreferences.CurrentLanguage)
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
    }
}
