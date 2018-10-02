using StoryTeller.CrossCutting.Disposable;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation
{
    public abstract class ContentFormatter : DisposableObject
    {
        public virtual async Task<string> GetFormattedContentAsync(string contentBetweenMarkers)
        {
            return contentBetweenMarkers;
        }
    }
}
