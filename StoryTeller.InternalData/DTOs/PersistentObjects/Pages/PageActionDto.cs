using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.Pages
{
    [Table("TB_PAGE_ACTIONS")]
    public class PageActionDto : BasePersistentObject
    {
        public string PageId { get;  set; }
        public string Description { get;  set; }
        public string PageIdToNagivate { get;  set; }
    }
}
