using StoryTeller.Core.Models.NameCalls;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.NameCalls
{
    public interface INameCallLocalRepository : IBaseRepository
    {
        Task<PronoumNameCall> GetPronoumByIdAsync(string pronoumId);
    }
}
