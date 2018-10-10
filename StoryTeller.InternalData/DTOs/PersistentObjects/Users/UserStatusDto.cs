using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.Users
{
    [Table("TB_USER_STATUS")]
    public class UserStatusDto : BasePersistentObject
    {
        public string SelectedCulture { get; set; }
        public string CurrentPageId { get; set; }
    }
}
