using SQLite;
using StoryTeller.Core.CharacterData;

namespace StoryTeller.Domain.Xamarin.Core.Entities.CharacterData
{
    [Table("TB_CHARACTERS")]
    public class XamarinCharacter : BaseEntity<Character>
    {
        public XamarinCharacter()
        {
            this.entity.Id
        }
    }
}
