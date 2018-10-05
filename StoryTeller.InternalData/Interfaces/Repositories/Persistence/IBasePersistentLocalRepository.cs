using StoryTeller.CrossCutting.Disposable;
using StoryTeller.InternalData.DTOs.PersistentObjects;

namespace StoryTeller.InternalData.Interfaces.Repositories.Persistence
{
    public interface IBasePersistentLocalRepository<T> : IDisposableObject where T : BasePersistentObject
    {
    }
}
