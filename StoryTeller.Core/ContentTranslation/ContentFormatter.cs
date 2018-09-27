namespace StoryTeller.Core.ContentTranslation
{
    public abstract class ContentFormatter
    {
        public abstract string GetFormattedContent(string contentBetweenMarkers);
    }
}
