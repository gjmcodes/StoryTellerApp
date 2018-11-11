using StoryTeller.Core.Disposing;
using StoryTeller.Core.Models.Pronoums;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Pronoums
{
    public interface IPronoumRepository : IDisposableObject
    {
        Task<Pronoum> GetPronoumByIdAsync(string pronoumId);
    }
}
