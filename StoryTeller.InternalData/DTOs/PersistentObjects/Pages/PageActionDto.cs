using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.Pages
{
    [Table("TB_PAGE_ACTIONS")]
    public class PageActionDto : BasePersistentObject
    {
        public string PageId { get; private set; }
        public string Description { get; private set; }
        public string PageIdToNagivate { get; private set; }
    }
}
