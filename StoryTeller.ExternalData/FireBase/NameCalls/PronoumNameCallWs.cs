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
        public PronoumNameCallWs(IUserStatusLocalRepository userStatusLocalRepository) 
            : base("PronoumNameCalls", userStatusLocalRepository)
        {
        }

        public async Task<IEnumerable<Pronoum>> GetPronoumNameCallsByCultureAsync()
        {
            var pronoums = await base.GetAllByCultureAsync<Pronoum>();

            return pronoums;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
