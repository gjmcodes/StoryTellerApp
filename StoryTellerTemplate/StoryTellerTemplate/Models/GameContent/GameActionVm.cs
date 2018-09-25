using StoryTeller.Core.Enums.Actions;

namespace StoryTellerTemplate.Models.GameContent
{
    public class GameActionVm
    {
        public GameActionVm(string description, string pageIdToFetch)
        {
            Description = description;
            PageIdToFetch = pageIdToFetch;
        }

        public string Description { get; private set; }
        public string PageIdToFetch { get; private set; }
    }
}
