using StoryTeller.CrossCutting.Disposable;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Interfaces.Services
{
    public interface ILocalDataManagerService : IDisposableObject
    {
        Task CreateLocalTablesAsync();
    }
}
