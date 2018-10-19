using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.CharactersData
{
    [Table("TB_CHARACTER")]
    public class CharacterDto : BasePersistentObject
    {
        public string Name { get; set; }

        public bool Gender { get; set; }
    }
}
