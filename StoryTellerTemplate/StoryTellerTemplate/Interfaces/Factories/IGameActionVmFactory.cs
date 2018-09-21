using StoryTeller.Core.Actions;
using StoryTeller.Core.Rooms;
using StoryTellerTemplate.Models.GameContent;
using System.Collections.Generic;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface IGameActionVmFactory : IBaseFactory
    {
        GameActionVm MapRoomActionToGameActionVm(RoomAction roomAction);
        IEnumerable<GameActionVm> MapRoomActionToGameActionVm(IEnumerable<RoomAction> roomActions);


        GameActionVm MapRoomActionToGameActionVm(DialogueAction dialogueAction);
    }
}
