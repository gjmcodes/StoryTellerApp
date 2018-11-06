using StoryTeller.Core.Pages;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.External.Persistence.Pages
{
    public interface IPageExternalRepository
    {
        Task CreatePageAsync(Page page, string culture);
    }
}
