using SQLite;

namespace StoryTeller.Xamarin.Domain.Entities.CharactersData
{
    [Table("TB_CHARACTER")]
    public class XamarinCharacter : BaseXamarinModel
    {
        public XamarinCharacter()
        {
        }

        public XamarinCharacter(string name, bool gender)
        {
            Name = name;
            Gender = gender;
        }

        public string Name { get;  set; }

        public bool Gender { get;  set; }

        public bool IsFemale => Gender;

        public string UserId { get;  set; }
    }
}
