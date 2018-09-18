using StoryTeller.Core.Enums.Actions;

namespace StoryTeller.Core.Actions
{
    public struct Action
    {
        public ActionTypeEnum actionType;
        public string description;
        public string roomToNavigateId;
        public string nextDialogueId;
    }
}
