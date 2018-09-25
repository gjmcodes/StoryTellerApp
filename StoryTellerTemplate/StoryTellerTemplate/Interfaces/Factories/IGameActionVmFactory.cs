using StoryTeller.Core.Actions;
using StoryTellerTemplate.Models.GameContent;
using System.Collections.Generic;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface IGameActionVmFactory : IBaseFactory
    {
        IEnumerable<GameActionVm> MapGameActionToVm(IEnumerable<GameAction> actions);
    }
}
