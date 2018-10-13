using StoryTeller.Core.GameCultures;
using StoryTeller.Core.Interfaces.Repositories.GameCultures;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.GameCulture
{
    public class GameCultureWs : BaseFirebaseWs, IGameCultureRepository
    {
        public GameCultureWs(IUserStatusLocalRepository userStatusLocalRepository)
            : base("GameCultures", userStatusLocalRepository)
        {
        }

        public async Task<IEnumerable<Culture>> GetGameCulturesAsync()
        {
            var cultures = new List<Culture>();

            var culturesRequest = await _fireBaseClient
                            .Child(collection).OnceAsync<Culture>();

            foreach (var item in culturesRequest)
            {
                cultures.Add(item.Object);
            }

            return cultures;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
