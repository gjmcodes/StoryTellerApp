using Firebase.Database;
using Firebase.Database.Query;
using StoryTeller.CrossCutting.Disposable;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase
{
    public abstract class BaseFirebaseWs : DisposableObject
    {
        protected string baseDatabaseUrl = "https://storyteller-92a39.firebaseio.com/";
        protected FirebaseClient _fireBaseClient;
        protected string collection;

        public BaseFirebaseWs(string collection)
        {
            this.collection = collection;
            _fireBaseClient = new FirebaseClient(baseDatabaseUrl);
        }

        protected async Task<IEnumerable<T>> GetByField<T>(string keyName, string keyValue, string fieldName, string fieldValue)
        {
            var objects = new List<T>();

            var request = await _fireBaseClient
                .Child(collection)
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

        protected async Task<IEnumerable<T>> GetByKey<T>(string keyName, string keyValue)
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
