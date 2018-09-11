using Firebase.Database;
using StoryTeller.CrossCutting.Disposable;

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

        protected BaseFirebaseWs()
        {
        }
    }
}
