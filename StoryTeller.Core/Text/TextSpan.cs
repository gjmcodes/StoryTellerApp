using StoryTeller.Core.Enums.Text;
using System;

namespace StoryTeller.Core.Text
{
    public struct TextSpan
    {
        //public TextSpan(string content,
        //    string hexForegroundColor,
        //    string hexBackgroundColor,
        //    string fontFamily,
        //    FontNamedSize fontSize,
        //    FontAttribute fontAttribute,
        //    bool lineBreak)
        //{
        //    this.content = content;
        //    this.hexForegroundColor = string.IsNullOrEmpty(hexForegroundColor) ? "#000" : hexForegroundColor;
        //    this.hexBackgroundColor = string.IsNullOrEmpty(hexBackgroundColor) ? "#efefe3" : hexBackgroundColor;
        //    this.fontFamily = fontFamily;
        //    this.fontSize = fontSize;
        //    this.fontAttribute = fontAttribute;
        //    this.lineBreak = lineBreak;
        //}

        public string content;
        public string Content => lineBreak ? Environment.NewLine : content;
        public string hexForegroundColor;
        public string hexBackgroundColor;
        public string fontFamily;
        public FontNamedSize fontSize;
        public FontAttribute fontAttribute;
        public bool lineBreak;

        public string HexForegroundColor => string.IsNullOrEmpty(hexForegroundColor) ? "#000" : hexForegroundColor;
        public string HexBackgroundColor => string.IsNullOrEmpty(hexBackgroundColor) ? "#efefe3" : hexBackgroundColor;
    }
}
