using SQLite;
using System;
using System.Text;

namespace StoryTeller.Xamarin.Domain.Entities.Pages
{
    [Table("TB_PAGE_CONTENT")]
    public class XamarinPageContent : BaseXamarinModel
    {
        public XamarinPageContent()
        {
        }

        public XamarinPageContent(
            string pageId,
            string content,
            string hexForegroundColor,
            string hexBackgroundColor,
            string fontFamily,
            int fontSize,
            int fontAttribute,
            bool lineBreak,
            int amountLineBreaks,
            string externalVersion)
        {
            PageId = pageId;
            FontFamily = fontFamily;
            FontSize = fontSize;
            FontAttribute = fontAttribute;

            this.content = content;
            this.hexForegroundColor = hexForegroundColor;
            this.hexBackgroundColor = hexBackgroundColor;
            this.lineBreak = lineBreak;
            this.amountLineBreaks = amountLineBreaks;
            this.ExternalTableVersion = externalVersion;
        }

        string hexForegroundColor;
        string hexBackgroundColor;
        string content;
        bool lineBreak;
        int amountLineBreaks;

        public string PageId { get; private set; }
        public string FontFamily { get; private set; }
        public int FontSize { get; private set; }
        public int FontAttribute { get; private set; }

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
