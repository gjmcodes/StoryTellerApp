using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.Users
{
    [Table("TB_USER_STATUS")]
    public class UserStatusDto : BasePersistentObject
    {
        public UserStatusDto(string currentPageId)
        {
            CurrentPageId = currentPageId;
        }

        public string CurrentPageId { get; private set; }
    }
}
