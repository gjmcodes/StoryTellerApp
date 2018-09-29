using SQLite;

namespace StoryTeller.Core.Models
{
    public abstract class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int LocalPk { get; set; }
    }
}
