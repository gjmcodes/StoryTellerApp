using StoryCreator.Web.Models.Rooms.Create;
using StoryTeller.Core.Actions;
using StoryTeller.Core.Rooms;
using System.Collections.Generic;

namespace StoryCreator.Web.Factories.Rooms
{
    public class RoomActionFactory
    {
        public RoomAction MapCreateRoomActionToRoomAction(CreateRoomActionVm createRoomActionVm, string roomId)
        {
            var roomAction = new RoomAction();
            roomAction.id = createRoomActionVm.Id;
            roomAction.roomId = roomId;

            roomAction.action = new GameAction();
            roomAction.action.actionType = createRoomActionVm.ActionType;
            roomAction.action.description = createRoomActionVm.Description;
            roomAction.action.dialogueToOpenId = createRoomActionVm.DialogueToOpenId;


            return roomAction;
        }

        public IEnumerable<RoomAction> MapCreateRoomActionToRoomAction(IEnumerable<CreateRoomActionVm> createRoomActionVms, string roomId)
        {
            var roomActions = new List<RoomAction>();
            foreach (var item in createRoomActionVms)
            {
                var obj = MapCreateRoomActionToRoomAction(item, roomId);
                roomActions.Add(obj);
            }

            return roomActions;
        }
    }
}
