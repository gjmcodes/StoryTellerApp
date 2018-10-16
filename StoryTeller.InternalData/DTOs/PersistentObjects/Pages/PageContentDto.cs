using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.Pages
{
    [Table("TB_PAGE_CONTENT")]
    public class PageContentDto : BasePersistentObject
    {
        public string PageId { get;  set; }
        public string Content { get;  set; }
        public string HexForegroundColor { get;  set; }
        public string HexBackgroundColor { get;  set; }
        public string FontFamily { get;  set; }
        public int FontSize { get;  set; }
        public int FontAttribute { get;  set; }
        public bool LineBreak { get;  set; }
        public int AmountLineBreaks { get;  set; }
    }
}
