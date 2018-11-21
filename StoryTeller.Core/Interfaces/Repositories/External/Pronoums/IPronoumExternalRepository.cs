using StoryTeller.Core.Models.Pronoums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.External.Pronoums
{
    public interface IPronoumExternalRepository
    {
        Task<PronoumRoot> GetPronoumNameCallsByCultureAsync();
    }
}
