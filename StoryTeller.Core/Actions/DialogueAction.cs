using StoryTeller.Core.Enums.Actions;

namespace StoryTeller.Core.Actions
{
    public struct DialogueAction
    {
        public ActionTypeEnum actionType;
        public string content;
        public string roomToNavigateId;
        public string nextDialogueId;
    }
}
