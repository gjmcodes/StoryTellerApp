using StoryTeller.Core.Disposing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Interfaces.Repositories.LocalRepository
{
    public interface IBaseLocalRepository : IDisposableObject
    {
        Task<bool> AddAsync<T>(T entity) where T : class;
        Task<bool> AddAsync<T>(IEnumerable<T> entities) where T : class;
        Task<bool> UpdateAsync<T>(T entity) where T : class;
    }
}
