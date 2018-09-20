using StoryTeller.Core.Enums.Actions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace StoryCreator.Web.Models.Rooms.Create
{
    public class CreateRoomActionVm
    {
        public CreateRoomActionVm(){}
        public CreateRoomActionVm(IEnumerable<string> cultures)
        {
            CultureDescription = new Dictionary<string, string>();
            foreach (var culture in cultures)
            {
                CultureDescription.Add(culture, string.Empty);
            }
        }
        public string Id { get; set; }

        [Description("Descrição")]
        public string DescriptionPreview => CultureDescription?["PT"] ?? string.Empty;

        public Dictionary<string, string> CultureDescription { get; set; }

        [Description("Id Para Room")]
        public string RoomToNavigateId { get; set; }

        [Description("Id Para Dialogue")]
        public string DialogueToOpenId { get; set; }

        [Description("Ação")]
        public ActionTypeEnum ActionType { get; set; }

        [Description("Cultura")]
        public string Culture { get; set; }

    }
}
