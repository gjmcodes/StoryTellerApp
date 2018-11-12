using StoryTeller.Core.Actions;
using StoryTeller.Xamarin.Domain.Entities.Pages;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Models.GameContent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Factories
{
    public class GameActionVmFactory : BaseFactory, IGameActionVmFactory
    {
        public async Task<IEnumerable<GameActionVm>> MapGameActionDtoToVmAsync(IEnumerable<XamarinPageAction> actions)
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

        public GameActionVm MapGameActionToVm(XamarinPageAction action)
        {
            var gameActionVm = new GameActionVm();
            gameActionVm.Description = action.Description;
            gameActionVm.PageIdToFetch = action.PageIdToNagivate;

            return gameActionVm;
        }

        public IEnumerable<GameActionVm> MapGameActionToVm(IEnumerable<XamarinPageAction> actions)
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
