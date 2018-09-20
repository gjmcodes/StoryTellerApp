using StoryCreator.Web.Models.Rooms.Create;
using StoryCreator.Web.Models.Rooms.PersistenceDto;
using StoryTeller.Core.Actions;
using StoryTeller.Core.Rooms;
using System.Collections.Generic;
using System.Linq;

namespace StoryCreator.Web.Factories.Rooms
{
    public class RoomActionFactory
    {
        public RoomAction MapCreateRoomActionToRoomAction(CreateRoomActionVm createRoomActionVm, string description, string roomId)
        {
            var roomAction = new RoomAction();
            roomAction.id = createRoomActionVm.Id;
            roomAction.roomId = roomId;

            roomAction.action = new GameAction();
            roomAction.action.actionType = createRoomActionVm.ActionType;
            roomAction.action.dialogueToOpenId = createRoomActionVm.DialogueToOpenId;
            roomAction.action.roomToNavigateId = createRoomActionVm.RoomToNavigateId;
            roomAction.action.description = description;

            return roomAction;
        }

        public IEnumerable<CultureRoomActionPersistence> MapToCultureRoomAction(IEnumerable<CreateRoomActionVm> createRoomActionVms, string roomId)
        {
            var persList = new List<CultureRoomActionPersistence>();

            var cultures = createRoomActionVms.SelectMany(x => x.CultureDescription).Select(x => x.Key).Distinct();

            foreach (var culture in cultures)
            {
                var persObj = new CultureRoomActionPersistence();
                persObj.culture = culture;
                persObj.roomActions = new List<RoomAction>();

                foreach (var item in createRoomActionVms)
                {
                    var act = MapCreateRoomActionToRoomAction(item, item.CultureDescription[culture], roomId);
                    persObj.roomActions.Add(act);
                }

                persList.Add(persObj);
            }

            return persList;
        }
    }
}
