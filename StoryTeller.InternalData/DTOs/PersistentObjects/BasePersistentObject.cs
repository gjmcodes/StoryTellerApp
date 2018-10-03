using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects
{
    public abstract class BasePersistentObject
    {
        [PrimaryKey, AutoIncrement]
        public int LocalPk { get; set; }
    }
}
