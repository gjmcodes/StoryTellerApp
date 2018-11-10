using SQLite;
using StoryTeller.Core.CharactersData;

namespace StoryTeller.Xamarin.Domain.Entities.CharactersData
{
    [Table("TB_CHARACTER")]
    public class XamarinCharacter : BaseXamarinModel
    {
        public XamarinCharacter(string name, bool gender)
        {
            Name = name;
            Gender = gender;
        }

        public string Name { get; private set; }

        public bool Gender { get; private set; }

        public bool IsFemale => Gender;
    }
}
