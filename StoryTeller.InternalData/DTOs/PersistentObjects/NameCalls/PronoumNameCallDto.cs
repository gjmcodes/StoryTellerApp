using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.NameCalls
{
    [Table("TB_PRONOUMS")]
    public class PronoumNameCallDto : BasePersistentObject
    {
        public string PronoumId { get; private set; }
        public string ForMale { get; private set; }
        public string ForFemale { get; private set; }
    }
}
