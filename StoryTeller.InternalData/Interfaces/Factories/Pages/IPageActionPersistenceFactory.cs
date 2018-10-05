using StoryTeller.Core.Actions;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Interfaces.Factories.Pages
{
    public interface IPageActionPersistenceFactory : IBaseLocalDataFactory
    {
        Task<IEnumerable<PageActionDto>> MapPageActionToDtoAsync(IEnumerable<GameAction> pageAction);
    }
}
