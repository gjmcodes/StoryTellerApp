using StoryTeller.Core.Enums.Text;

namespace StoryCreator.Web.Models.Contents
{
    public class ContentViewModel
    {
        public string Content { get; set; }
        public string HexForegroundColor { get; set; }
        public string HexBackgroundColor { get; set; }
        public string FontFamily { get; set; }
        public FontNamedSize FontSize { get; set; }
        public FontAttribute FontAttribute { get; set; }
        public bool LineBreak { get; set; }
        public int AmountLineBreaks { get; set; }
    }
}
