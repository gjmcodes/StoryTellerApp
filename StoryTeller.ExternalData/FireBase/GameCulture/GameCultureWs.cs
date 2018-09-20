using StoryTeller.Core.GameCultures;
using StoryTeller.Core.Interfaces.Repositories.GameCultures;
using StoryTeller.CrossCutting.User.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.GameCulture
{
    public class GameCultureWs : BaseFirebaseWs, IGameCultureRepository
    {
        public GameCultureWs(UserPreferences userPreferences)
            : base("GameCultures", userPreferences)
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
