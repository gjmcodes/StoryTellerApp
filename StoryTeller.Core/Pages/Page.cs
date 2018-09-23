using StoryTeller.Core.Actions;
using System.Collections.Generic;

namespace StoryTeller.Core.Pages
{
    public struct Page
    {
        public string pageId;
        public PageContent content;
        public IEnumerable<GameAction> actions;
    }
}
