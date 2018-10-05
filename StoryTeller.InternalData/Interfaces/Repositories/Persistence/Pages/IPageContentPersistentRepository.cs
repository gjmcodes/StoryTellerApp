using StoryTeller.Core.Text;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Interfaces.Repositories.Persistence.Pages
{
    public interface IPageContentPersistentRepository : IBasePersistentLocalRepository<PageContentDto>
    {
        Task<bool> InsertPageContentsAsync(IEnumerable<TextSpan> pageContents, string pageId);
    }
}
