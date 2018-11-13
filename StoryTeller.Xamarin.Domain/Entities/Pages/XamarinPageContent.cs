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

            this.Content = content;
            this.HexForegroundColor = hexForegroundColor;
            this.HexBackgroundColor = hexBackgroundColor;
            this.LineBreak = lineBreak;
            this.AmountLineBreaks = amountLineBreaks;
            this.ExternalTableVersion = externalVersion;
        }

        public string HexForegroundColor { get; set; }
        public string HexBackgroundColor { get; set; }
        public string Content { get; set; }
        public bool LineBreak { get; set; }
        int AmountLineBreaks { get; set; }

        public string PageId { get; set; }
        public string FontFamily { get; set; }
        public int FontSize { get; set; }
        public int FontAttribute { get; set; }

        public string GetHexForegroundColor => string.IsNullOrEmpty(HexForegroundColor) ? "#000" : HexForegroundColor;
        public string GetHexBackgroundColor => string.IsNullOrEmpty(HexBackgroundColor) ? "#FF" : HexBackgroundColor;
        public bool GetLineBreak => LineBreak;
        public string GetContent => LineBreak ? GetAmountNewLines() : Content;

        string GetAmountNewLines()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < AmountLineBreaks; i++)
            {
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
