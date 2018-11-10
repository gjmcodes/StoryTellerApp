using StoryTeller.Core.Models.NameCalls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.External.Pronoums
{
    public interface IPronoumExternalRepository
    {
        Task<IEnumerable<PronoumNameCall>> GetPronoumNameCallsByCultureAsync();
    }
}
