using SQLite;

namespace StoryTeller.Xamarin.Domain.Entities.App
{
    [Table("TB_USER_SETTINGS")]
    public class XamarinUserSettings : BaseXamarinModel
    {
        public XamarinUserSettings()
        {
        }

        public XamarinUserSettings(string userId, string selectedCulture, string selectedCharacterId)
        {
            UserId = userId;
            SelectedCulture = selectedCulture;
            SelectedCharacterId = selectedCharacterId;
        }

        public string UserId { get; set; }
        public string SelectedCulture { get; set; }
        public string SelectedCharacterId { get; set; }
    }
}
