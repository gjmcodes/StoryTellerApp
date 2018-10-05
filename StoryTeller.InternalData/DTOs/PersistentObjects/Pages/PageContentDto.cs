using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.Pages
{
    [Table("TB_PAGE_CONTENT")]
    public class PageContentDto : BasePersistentObject
    {
        public string PageId { get; private set; }
        public string Content { get; private set; }
        public string HexForegroundColor { get; private set; }
        public string HexBackgroundColor { get; private set; }
        public string FontFamily { get; private set; }
        public int FontSize { get; private set; }
        public int FontAttribute { get; private set; }
        public bool LineBreak { get; private set; }
        public int AmountLineBreaks { get; private set; }
    }
}
