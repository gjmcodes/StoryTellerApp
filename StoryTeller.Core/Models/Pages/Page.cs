using StoryTeller.Core.Actions;
using StoryTeller.Core.Models;
using System.Collections.Generic;

namespace StoryTeller.Core.Pages
{
    public class Page : BaseExternalEntity
    {
        public string pageId;
        public string title;
        public string image;
        public PageContent content;
        public IEnumerable<GameAction> actions;
    }
}
