using StoryTeller.Core.Enums.Text;
using System;
using System.Text;

namespace StoryTeller.Core.Text
{
    public struct TextSpan
    {

        public string content;
        public string hexForegroundColor;
        public string hexBackgroundColor;
        public string fontFamily;
        public FontNamedSize fontSize;
        public FontAttribute fontAttribute;
        public bool lineBreak;
        public int amountLineBreaks;

        public string HexForegroundColor => string.IsNullOrEmpty(hexForegroundColor) ? "#000" : hexForegroundColor;
        public string HexBackgroundColor => string.IsNullOrEmpty(hexBackgroundColor) ? "#FF" : hexBackgroundColor;
        public string Content => lineBreak ? GetAmountNewLines() : content;

        string GetAmountNewLines()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < amountLineBreaks; i++)
            {
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
