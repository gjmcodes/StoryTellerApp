using StoryTeller.Core.GameCultures;
using StoryTeller.Core.Interfaces.Repositories.GameCultures;
using StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.GameCulture
{
    public class GameCultureWs : BaseFirebaseWs, IGameCultureRepository
    {
        public GameCultureWs(IUserStatusLocalRepository userStatusLocalRepository)
            : base("GameCultures", userStatusLocalRepository)
        {
        }

        public async Task<Cultures> GetGameCulturesAsync()
        {
            var cultures = await _fireBaseClient
                            .Child(collection).OnceSingleAsync<Cultures>();

            return cultures;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
