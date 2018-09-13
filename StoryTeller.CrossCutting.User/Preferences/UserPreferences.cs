namespace StoryTeller.CrossCutting.User.Preferences
{
    public struct UserPreferences
    {
        string currentLanguage;

        public string CurrentLanguage => string.IsNullOrEmpty(currentLanguage) ? "PT" : currentLanguage;
    }
}
