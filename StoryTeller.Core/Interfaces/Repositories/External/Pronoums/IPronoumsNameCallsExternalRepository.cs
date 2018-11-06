using StoryTeller.Core.Models.NameCalls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.External.Pronoums
{
    public interface IPronoumsNameCallsExternalRepository
    {
        Task<IEnumerable<PronoumNameCall>> GetPronoumNameCallsByCultureAsync(string culture);
    }
}
