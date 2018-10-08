using StoryTeller.CrossCutting.Disposable;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories
{
    public interface IBaseRepository : IDisposableObject 
    {
        Task<bool> AddAsync<T>(T entity) where T : class;
        Task<bool> AddAsync<T>(IEnumerable<T> entities) where T : class;
    }
}
