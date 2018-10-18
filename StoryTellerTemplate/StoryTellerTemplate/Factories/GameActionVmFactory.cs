using StoryTeller.Core.Actions;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Models.GameContent;
using System.Collections.Generic;

namespace StoryTellerTemplate.Factories
{
    public class GameActionVmFactory : BaseFactory, IGameActionVmFactory
    {

        public GameActionVm MapGameActionToVm(GameAction action)
        {
            var gameActionVm = new GameActionVm();
            gameActionVm.Description = action.description;
            gameActionVm.PageIdToFetch = action.pageIdToNavigate;

            return gameActionVm;
        }

        public IEnumerable<GameActionVm> MapGameActionToVm(IEnumerable<GameAction> actions)
        {
            var gameActionsVms = new List<GameActionVm>();

            foreach (var item in actions)
            {
                var act = MapGameActionToVm(item);
                gameActionsVms.Add(act);
            }

            return gameActionsVms;
        }

    }
}
