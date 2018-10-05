using StoryTeller.Core.Models.NameCalls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.Persistence.NameCalls
{
    public interface IPronoumLocalPersistentRepository : IBaseRepository
    {
        Task<bool> PersistNameCallsAsync(IEnumerable<PronoumNameCall> nameCalls);
    }
}
