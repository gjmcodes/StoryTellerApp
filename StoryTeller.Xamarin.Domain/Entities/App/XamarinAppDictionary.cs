using SQLite;

namespace StoryTeller.Xamarin.Domain.Entities.App
{
    [Table("TB_APP_DICTIONARY")]
    public class XamarinAppDictionary : BaseXamarinModel
    {
        public XamarinAppDictionary()
        {
        }

        public XamarinAppDictionary(string exit, string male, string female, string languages, string namePlaceholder, string version)
        {
            Exit = exit;
            Male = male;
            Female = female;
            Languages = languages;
            NamePlaceholder = namePlaceholder;
            base.ExternalTableVersion = version;
        }

        public string Exit { get; private set; }
        public string Male { get; private set; }
        public string Female { get; private set; }
        public string Languages { get; private set; }
        public string NamePlaceholder { get; private set; }
    }
}
