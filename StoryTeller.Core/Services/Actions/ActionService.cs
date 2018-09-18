using StoryTeller.Core.Dialogues;
using StoryTeller.Core.Interfaces.Services.Actions;
using StoryTeller.Core.Rooms;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.Actions
{
    public class ActionService : BaseService, IActionService
    {
        public async Task<Room> GetRoomForNavigationActionAsync(string roomId)
        {
            return new Room();
        }

        public async Task<Dialogue> GetDialogueForDialogueActionAsync(string dialogueId)
        {
            return new Dialogue();
        }
    }
}
