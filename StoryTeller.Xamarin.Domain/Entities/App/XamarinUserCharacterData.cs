using SQLite;

namespace StoryTeller.Xamarin.Domain.Entities.App
{
    [Table("TB_USER_CHARACTERS")]
    public class XamarinUserCharacterData
    {
        public string UserId { get; private set; }
        public string CharacterId { get; private set; }
        public string CharacterCurrentPageId { get; private set; }
    }
}
