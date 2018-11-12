using StoryTeller.Core.GameCultures;
using StoryTeller.Core.Interfaces.Repositories.GameCultures;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Models.GameCultures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.GameCulture
{
    public class GameCultureWs : BaseFirebaseWs, IGameCultureRepository
    {
        public GameCultureWs(IUserLocalRepository userStatusLocalRepository)
            : base("GameCultures", userStatusLocalRepository)
        {
        }

        public async Task<IEnumerable<Culture>> GetGameCulturesAsync()
        {
            var culturesRequest = await _fireBaseClient
                            .Child(collection).OnceSingleAsync<IEnumerable<Culture>>();

            return culturesRequest;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
