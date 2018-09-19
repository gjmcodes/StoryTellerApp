using StoryTeller.Core.Enums.Text;

namespace StoryCreator.Web.Models.Contents
{
    public struct ContentTranslationDto
    {
        public string paragraphId;
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
