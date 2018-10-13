using StoryTeller.Core.Models.NameCalls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.NameCalls
{
    public interface IPronoumLocalRepository : IBaseRepository
    {
        Task<bool> PersistNameCallsAsync(IEnumerable<PronoumNameCall> nameCalls);
    }
}
