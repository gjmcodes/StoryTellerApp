namespace StoryTeller.Core.ContentTranslation
{
    public abstract class ContentFormatter
    {
        public abstract ContentTranslationDto GetContent();

        public virtual string GetFormattedContent(string contentBetweenMarkers)
        {
            return contentBetweenMarkers;
        }
    }
}
