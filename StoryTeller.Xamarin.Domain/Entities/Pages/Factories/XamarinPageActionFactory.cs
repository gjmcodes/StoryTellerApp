using StoryTeller.Core.Actions;
using StoryTeller.Xamarin.Domain.Entities.Pages;
using StoryTeller.Xamarin.Domain.Entities.Pages.Factories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Factories.Pages
{
    public class XamarinPageActionFactory : BaseFactory, IXamarinPageActionFactory
    {
        public async Task<XamarinPageAction> MapActionToXamarinAsync(GameAction gameAction, string pageId, string pageVersion)
        {
            return await Task.Run(() =>
            {
                var xamPgAct = new XamarinPageAction(
                    pageId, 
                    gameAction.description, 
                    gameAction.pageIdToNavigate,
                    pageVersion);

                return xamPgAct;
            });
        }

        public async Task<IEnumerable<XamarinPageAction>> MapActionToXamarinAsync(IEnumerable<GameAction> gameActions, string pageId, string pageVersion)
        {
            var actions = new List<XamarinPageAction>();
            foreach (var item in gameActions)
            {
                var xamAct = await MapActionToXamarinAsync(item, pageId, pageVersion);
                actions.Add(xamAct);
            }

            return actions;
        }
    }
}
