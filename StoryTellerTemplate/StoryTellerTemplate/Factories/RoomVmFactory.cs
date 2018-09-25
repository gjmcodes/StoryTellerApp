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

        public PageVm MapRoomToRoomVm(Room room)
        {
            var roomVm = new PageVm();
            var content = _textSpanFactory.MapTextSpanToXamarinSpan(room.content.textSpans);

            roomVm.Content = content;

            return roomVm;
        }
    }
}
