using StoryCreator.Web.Models.Contents;
using System.Collections.Generic;
using System.ComponentModel;

namespace StoryCreator.Web.Models.Rooms.Create
{
    public class CreateRoomContentVm
    {
        public CreateRoomContentVm(){}

        public CreateRoomContentVm(IEnumerable<string> cultures)
        {
            CultureContent = new Dictionary<string, string>();
            foreach (var culture in cultures)
            {
                CultureContent.Add(culture, string.Empty);
            }
        }

        public string Id { get; set; }
        public string RoomId { get; set; }

        public string ContentPreview => CultureContent?["PT"] ?? string.Empty;

        public Dictionary<string, string> CultureContent { get; set; }
    }
}
