using SQLite;

namespace StoryTeller.Xamarin.Domain.Entities.App
{
    [Table("TB_USER_SETTINGS")]
    public class XamarinUserSettings
    {
        public XamarinUserSettings()
        {
        }

        public string UserId { get; private set; }
        public string SelectedCulture { get; private set; }
        public string SelectedCharacterId { get; private set; }
    }
}
