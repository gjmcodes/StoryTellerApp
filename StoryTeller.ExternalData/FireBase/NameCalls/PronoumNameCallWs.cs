using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StoryTeller.Core.Interfaces.Repositories.External.Pronoums;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Models.Pronoums;

namespace StoryTeller.ExternalData.FireBase.NameCalls
{
    public class PronoumNameCallWs : BaseFirebaseWs, IPronoumExternalRepository
    {
        public PronoumNameCallWs(IUserLocalRepository userStatusLocalRepository)
            : base("PronoumNameCalls", userStatusLocalRepository)
        {
        }

        public async Task<PronoumRoot> GetPronoumNameCallsByCultureAsync()
        {
            var langQuery = await base.QueryableCollectionWithLanguageAsync();

            var pronoums = await langQuery.OnceSingleAsync<PronoumRoot>();

            return pronoums;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
