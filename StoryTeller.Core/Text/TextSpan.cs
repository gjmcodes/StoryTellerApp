﻿using StoryTeller.Core.Enums.Text;
using System;

namespace StoryTeller.Core.Text
{
    public struct TextSpan
    {
        public TextSpan(string content)
        {
            this.content = content;
            this.hexForegroundColor = null;
            this.hexBackgroundColor = null;
            this.fontFamily = null;
            this.fontSize = FontNamedSize.Default;
            this.fontAttribute = FontAttribute.None;
        }

        public TextSpan(string content, 
            string hexForegroundColor,
            string hexBackgroundColor,
            string fontFamily, 
            FontNamedSize fontSize, 
            FontAttribute fontAttribute)
        {
            this.content = content;
            this.hexForegroundColor = string.IsNullOrEmpty(hexForegroundColor) ? "#000" : hexForegroundColor;
            this.hexBackgroundColor = string.IsNullOrEmpty( hexBackgroundColor) ? "#efefe3" : hexBackgroundColor;
            this.fontFamily = fontFamily;
            this.fontSize = fontSize;
            this.fontAttribute = fontAttribute;
        }

        public string content;
        public string hexForegroundColor;
        public string hexBackgroundColor;
        public string fontFamily;
        public FontNamedSize fontSize;
        public FontAttribute fontAttribute;

        public bool IsNewLine => content == Environment.NewLine;
        
    }
}
