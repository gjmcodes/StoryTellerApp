using StoryTeller.Core.Rooms;
using StoryTellerTemplate.Models.MainPage;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface IRoomVmFactory : IBaseFactory
    {
        RoomVm MapRoomToRoomVm(Room room);
    }
}
