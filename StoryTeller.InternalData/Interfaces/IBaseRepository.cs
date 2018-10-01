using StoryTeller.CrossCutting.Disposable;

namespace StoryTeller.InternalData.Interfaces
{
    public interface IBaseRepository<T> :  IDisposableObject where T : new()
    {
    }
}
