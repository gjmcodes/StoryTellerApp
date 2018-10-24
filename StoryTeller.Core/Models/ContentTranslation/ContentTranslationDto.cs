using StoryTeller.Core.Enums.Text;

namespace StoryTeller.Core.ContentTranslation
{
    public struct ContentTranslationDto
    {
        public string content;
        public string hexForegroundColor;
        public string hexBackgroundColor;
        public string fontFamily;
        public FontNamedSize fontSize;
        public FontAttribute fontAttribute;
        public bool lineBreak;
        public int amountLineBreaks;
    }
}
