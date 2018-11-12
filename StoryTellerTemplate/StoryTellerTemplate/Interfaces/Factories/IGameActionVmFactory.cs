using StoryTeller.Xamarin.Domain.Entities.Pages;
using StoryTellerTemplate.Models.GameContent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface IGameActionVmFactory : IBaseFactory
    {
        IEnumerable<GameActionVm> MapGameActionToVm(IEnumerable<XamarinPageAction> actions);
        Task<IEnumerable<GameActionVm>> MapGameActionDtoToVmAsync(IEnumerable<XamarinPageAction> actions);
    }
}
