using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StoryTeller.Core.Interfaces.Repositories.External.NameCalls;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Models.NameCalls;

namespace StoryTeller.ExternalData.FireBase.NameCalls
{
    public class PronoumNameCallWs : BaseFirebaseWs, IPronoumsNameCallsExternalRepository
    {
        public PronoumNameCallWs(IUserStatusLocalRepository userStatusLocalRepository) 
            : base("PronoumNameCalls", userStatusLocalRepository)
        {
        }

        public async Task<IEnumerable<PronoumNameCall>> GetPronoumNameCallsByCultureAsync(string culture)
        {
            var pronoums = await base.GetAllByCultureAsync<PronoumNameCall>();

            return pronoums;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
