using StoryTeller.Core.Actions;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTellerTemplate.Models.GameContent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface IGameActionVmFactory : IBaseFactory
    {
        IEnumerable<GameActionVm> MapGameActionToVm(IEnumerable<GameAction> actions);
        Task<IEnumerable<GameActionVm>> MapGameActionDtoToVmAsync(IEnumerable<PageActionDto> actions);
    }
}
