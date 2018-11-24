using StoryTeller.Core.Disposing;
using StoryTeller.Core.Models.Pronoums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.External.Pronoums
{
    public interface IPronoumExternalRepository : IDisposableObject
    {
        Task<IEnumerable<Pronoum>> GetPronoumsByCultureAsync();
    }
}
