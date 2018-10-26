using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects
{
    public class BasePersistentObject
    {
        public BasePersistentObject()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int LocalPk { get; set; }

        public int ExternalTableVersion { get; set; }
    }
}
