using StoryTeller.Core.Actions;
using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.Text;
using System.Collections.Generic;

namespace StoryTeller.Core.Models.Pages.DTOs
{
    public struct TranslatedPageDto
    {
        public string PageId { get; set; }
        public IEnumerable<TextSpan> TranslatedContent { get; set; }
        public IEnumerable<GameAction> PageActions { get; set; }
    }
}
