using StoryTeller.Core.Text;
using System.Collections.Generic;

namespace StoryTeller.Core.Dialogues
{
    public struct DialogueContent
    {
        public string id;
        public string dialogueId;
        public IEnumerable<TextSpan> content;
    }
}
