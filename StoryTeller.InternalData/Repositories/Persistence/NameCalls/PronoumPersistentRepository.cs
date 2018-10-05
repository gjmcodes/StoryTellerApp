using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.NameCalls;
using StoryTeller.Core.Models.NameCalls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Repositories.Persistence.NameCalls
{
    public class PronoumPersistentRepository : BaseRepository, IPronoumLocalPersistentRepository
    {
        public async Task<bool> PersistNameCallsAsync(IEnumerable<PronoumNameCall> nameCalls)
        {
            throw new NotImplementedException();
        }
    }
}
