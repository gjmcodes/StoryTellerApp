using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.Pages
{
    [Table("TB_PAGES")]
    public class PageDto : BasePersistentObject
    {
        public string PageId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        [Ignore]
        public IEnumerable<PageActionDto> PageActionsDtos { get; set; }

        [Ignore]
        public IEnumerable<PageContentDto> PageContentDtos { get; set; }
    }
}
