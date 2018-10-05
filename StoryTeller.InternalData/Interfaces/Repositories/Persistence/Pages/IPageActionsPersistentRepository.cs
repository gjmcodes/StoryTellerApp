using StoryTeller.Core.Actions;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Interfaces.Repositories.Persistence.Pages
{
    public interface IPageActionsPersistentRepository : IBasePersistentLocalRepository<PageActionDto>
    {
        Task<bool> InsertPageActionsAsync(IEnumerable<GameAction> pageActions, string pageId);
    }
}
