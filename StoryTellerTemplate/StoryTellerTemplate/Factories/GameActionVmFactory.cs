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
        public GameActionVm MapRoomActionToGameActionVm(RoomAction roomAction)
        {
            var gameActionVm = new GameActionVm(
                roomAction.id, 
                roomAction.action.actionType, 
                roomAction.action.description,
                roomAction.action.GetIdToFetch());

            return gameActionVm;
        }

        public GameActionVm MapRoomActionToGameActionVm(DialogueAction dialogueAction)
        {
            var gameActionVm = new GameActionVm(
                dialogueAction.id,
                dialogueAction.action.actionType,
                dialogueAction.action.description,
                dialogueAction.action.GetIdToFetch());

            return gameActionVm;
        }
    }
}
