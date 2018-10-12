using SQLite;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.CharactersData
{
    [Table("TB_CHARACTER")]
    public class CharacterDto : BasePersistentObject
    {
        public CharacterDto()
        {
        }

        public CharacterDto(string name, bool gender)
        {
            Name = name;
            Gender = gender;
        }

        public string Name { get; private set; }

        public bool Gender { get; private set; }
    }
}
