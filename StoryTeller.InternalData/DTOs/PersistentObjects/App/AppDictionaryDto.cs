using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.App
{
    [Table("TB_APP_DICTIONARY")]
    public class AppDictionaryDto : BasePersistentObject
    {
        public string Exit { get; set; }
        public string Male { get; set; }
        public string Female { get; set; }
        public string Languages { get; set; }
        public string NamePlaceholder { get; set; }
    }
}
