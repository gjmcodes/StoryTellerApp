using StoryTeller.Core.Enums.Actions;

namespace StoryTellerTemplate.Models.GameContent
{
    public class GameActionVm
    {
        public GameActionVm(string id, ActionTypeEnum actionType, string description, string idToFetch)
        {
            Id = id;
            ActionType = actionType;
            Description = description;
            IdToFetch = idToFetch;
        }

        public string Id { get; private set; }
        public ActionTypeEnum ActionType { get; private set; }
        public string Description { get; private set; }
        public string IdToFetch { get; private set; }
    }
}
