using SQLite;
using StoryTeller.Core.CharactersData;

namespace StoryTeller.Xamarin.Domain.Entities.CharactersData
{
    [Table("TB_CHARACTER")]
    public class XamarinCharacter : BaseXamarinModel
    {
        public XamarinCharacter()
        {
        }

        public string UserId { get; set; }

        public string CharacterId { get; set; }

        public string Name { get; set; }

        public bool Gender { get; set; }

        public bool IsFemale => Gender;

        public XamarinCharacter CreateNewCharacter(string name, bool gender)
        {
            var chara = Character.CreateNewCharacter(name, gender, string.Empty);

            var xamChara = new XamarinCharacter();
            xamChara.Name = chara.Name;
            xamChara.Gender = chara.Gender;
            xamChara.CharacterId = chara.CharacterId;

            return xamChara;
        }
    }
}
