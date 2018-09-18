namespace StoryTeller.CrossCutting.User.Preferences
{
    public class UserPreferences
    {
        string currentLanguage;

        public string CurrentLanguage => string.IsNullOrEmpty(currentLanguage) ? "PT" : currentLanguage;
    }
}
