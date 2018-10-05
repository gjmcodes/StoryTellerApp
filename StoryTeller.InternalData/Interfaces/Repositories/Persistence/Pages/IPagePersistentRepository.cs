using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Pages;
using StoryTeller.Core.Pages;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;

namespace StoryTeller.InternalData.Interfaces.Repositories.Persistence.Pages
{
    public interface IPagePersistentRepository : IBaseExternalPersistenceLocalRepository<PageDto, Page>, IPageLocalPersistentRepository
    {
    }
}
