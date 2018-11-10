using StoryTeller.Core.Actions;
using StoryTeller.Core.Models;
using System.Collections.Generic;

namespace StoryTeller.Core.Pages
{
    public class Page : BaseEntity
    {
        public string PageId { get; private set; }
        public string Title { get; private set; }
        public string Image { get; private set; }

        public PageContent Content { get; private set; }
        public IEnumerable<GameAction> Actions { get; private set; }
    }
}
