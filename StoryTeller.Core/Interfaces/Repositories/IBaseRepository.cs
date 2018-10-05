using StoryTeller.CrossCutting.Disposable;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> : IDisposableObject where T : class 
    {
    }
}
