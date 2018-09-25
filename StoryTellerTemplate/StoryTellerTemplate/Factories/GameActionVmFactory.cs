using StoryTeller.Core.Actions;
using StoryTeller.Core.Rooms;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Models.GameContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoryTellerTemplate.Factories
{
    public class GameActionVmFactory : BaseFactory, IGameActionVmFactory
    {

        public GameActionVm MapGameActionToVm(GameAction action)
        {
            var gameActionVm = new GameActionVm(
            action.description,
            action.pageIdToNavigate);

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
