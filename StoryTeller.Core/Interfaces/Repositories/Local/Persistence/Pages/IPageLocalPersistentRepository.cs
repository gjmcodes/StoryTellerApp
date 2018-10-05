using StoryTeller.Core.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Pages
{
    public interface IPageLocalPersistentRepository : IBaseRepository
    {
        Task<bool> AddAsync(IEnumerable<Page> entities);
    }
}
