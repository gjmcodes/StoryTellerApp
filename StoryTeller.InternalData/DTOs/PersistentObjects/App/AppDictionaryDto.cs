using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.App
{
    [Table("TB_APP_DICTIONARY")]
    public class AppDictionaryDto : BasePersistentObject
    {
        public string Exit { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public string NamePlaceholder { get; set; }
    }
}
