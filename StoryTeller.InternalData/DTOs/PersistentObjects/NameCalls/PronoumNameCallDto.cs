using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.NameCalls
{
    [Table("TB_PRONOUMS")]
    public class PronoumNameCallDto : BasePersistentObject
    {
        public string PronoumId { get; set; }
        public string ForMale { get; set; }
        public string ForFemale { get; set; }
    }
}
