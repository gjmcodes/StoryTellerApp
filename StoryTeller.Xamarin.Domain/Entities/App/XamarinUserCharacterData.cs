using SQLite;

namespace StoryTeller.Xamarin.Domain.Entities.App
{
    [Table("TB_USER_CHARACTERS")]
    public class XamarinUserCharacterData : BaseXamarinModel
    {
        public XamarinUserCharacterData()
        {
        }

        public XamarinUserCharacterData(string userId, string characterId, string characterCurrentPageId)
        {
            UserId = userId;
            CharacterId = characterId;
            CharacterCurrentPageId = characterCurrentPageId;
        }

        public string UserId { get; private set; }
        public string CharacterId { get; private set; }
        public string CharacterCurrentPageId { get; private set; }
    }
}
