using StoryTeller.Core.Actions;
using System.Collections.Generic;

namespace StoryTeller.Core.Dialogues
{
    public struct Dialogue
    {
        public string dialogueId;
        public string content;
        public Dictionary<string, DialogueAction> dialogueOptions;
    }
}
