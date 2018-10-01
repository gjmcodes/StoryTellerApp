using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation
{
    public abstract class ContentFormatter
    {
        public virtual async Task<string> GetFormattedContentAsync(string contentBetweenMarkers)
        {
            return contentBetweenMarkers;
        }
    }
}
