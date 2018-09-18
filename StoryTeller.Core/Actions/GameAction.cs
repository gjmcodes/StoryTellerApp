using StoryTeller.Core.Enums.Actions;

namespace StoryTeller.Core.Actions
{
    public struct GameAction
    {
        public string description;
        public string roomActionType;
        public string roomToNavigateId;
        public string dialogueToOpenId;

        public ActionTypeEnum actionType;

        public string GetIdToFetch()
        {
            if (actionType == ActionTypeEnum.Dialogue)
                return dialogueToOpenId;

            return roomToNavigateId;
        }
    }
}
