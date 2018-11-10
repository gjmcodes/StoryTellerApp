using StoryTeller.Core.Interfaces.Repositories;
using StoryTeller.Core.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.Pages.Repositories
{
    public interface IPageLocalRepository : IBaseRepository
    {
        Task<XamarinPage> GetPageByIdAsync(string pageId);
        Task<bool> AddPagesAsync(IEnumerable<Page> entities);
    }
}
