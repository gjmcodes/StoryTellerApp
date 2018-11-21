using StoryTeller.Core.Actions;
using StoryTeller.Core.Disposing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.Pages.Factories.Interfaces
{
    public interface IXamarinPageActionFactory : IDisposableObject
    {
        Task<XamarinPageAction> MapActionToXamarinAsync(GameAction gameAction, string pageId, int pageVersion);
        Task<IEnumerable<XamarinPageAction>> MapActionToXamarinAsync(IEnumerable<GameAction> gameActions, string pageId, int pageVersion);
    }
}
