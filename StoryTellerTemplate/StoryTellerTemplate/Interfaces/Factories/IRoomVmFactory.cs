using StoryTeller.Core.Rooms;
using StoryTellerTemplate.Models.MainPage;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface IRoomVmFactory : IBaseFactory
    {
        PageVm MapRoomToRoomVm(Room room);
    }
}
