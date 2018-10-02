using SQLite;
using StoryTeller.Core.Models;

namespace StoryTeller.Core.CharacterData
{
    [Table("TB_CHARACTER")]
    public class Character : BaseEntity
    {

        public string Name { get; private set; }

        public bool Gender { get; private set; }

        public bool IsFemale => Gender;
    }
}
