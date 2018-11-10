using StoryTeller.Core.Actions;
using StoryTeller.Core.Disposing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.Pages.Factories.Interfaces
{
    public interface IXamarinPageActionFactory : IDisposableObject
    {
        Task<XamarinPageAction> MapActionToXamarinAsync(GameAction gameAction, string pageId, string pageVersion);
        Task<IEnumerable<XamarinPageAction>> MapActionToXamarinAsync(IEnumerable<GameAction> gameActions, string pageId, string pageVersion);
    }
}
