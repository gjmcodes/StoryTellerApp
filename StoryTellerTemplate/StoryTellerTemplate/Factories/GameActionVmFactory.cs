using StoryTeller.Core.Actions;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Models.GameContent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Factories
{
    public class GameActionVmFactory : BaseFactory, IGameActionVmFactory
    {
        public async Task<IEnumerable<GameActionVm>> MapGameActionDtoToVmAsync(IEnumerable<PageActionDto> actions)
        {
            return await Task.Run(() =>
            {

                var actionVMs = new List<GameActionVm>();
                foreach (var item in actions)
                {
                    var action = new GameActionVm();
                    action.Description = item.Description;
                    action.PageIdToFetch = item.PageIdToNagivate;

                    actionVMs.Add(action);
                }

                return actionVMs;
            });
        }

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
