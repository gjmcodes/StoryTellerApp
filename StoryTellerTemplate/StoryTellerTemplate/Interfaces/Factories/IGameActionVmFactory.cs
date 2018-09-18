using StoryTeller.Core.Actions;
using StoryTeller.Core.Rooms;
using StoryTellerTemplate.Models.GameContent;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface IGameActionVmFactory : IBaseFactory
    {
        GameActionVm MapRoomActionToGameActionVm(RoomAction roomAction);
        GameActionVm MapRoomActionToGameActionVm(DialogueAction dialogueAction);
    }
}
