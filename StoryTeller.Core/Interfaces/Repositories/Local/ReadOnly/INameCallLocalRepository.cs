using StoryTeller.Core.NameCalls;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly
{
    public interface INameCallLocalRepository : IBaseRepository
    {
        Task<PronoumNameCall> GetPronoumByIdAsync(string pronoumId);
    }
}
