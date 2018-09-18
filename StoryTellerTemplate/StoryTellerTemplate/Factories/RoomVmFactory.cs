using StoryTeller.Core.Rooms;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Models.MainPage;

namespace StoryTellerTemplate.Factories
{
    public class RoomVmFactory : BaseFactory, IRoomVmFactory
    {
        private readonly ITextSpanFactory _textSpanFactory;

        public RoomVmFactory(ITextSpanFactory textSpanFactory)
        {
            _textSpanFactory = textSpanFactory;
        }

        public RoomVm MapRoomToRoomVm(Room room)
        {
            var roomVm = new RoomVm();
            var content = _textSpanFactory.MapTextSpanToXamarinSpan(room.Content.content);

            roomVm.Content = content;

            return roomVm;
        }
    }
}
