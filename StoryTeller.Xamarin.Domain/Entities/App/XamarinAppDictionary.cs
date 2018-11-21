using SQLite;

namespace StoryTeller.Xamarin.Domain.Entities.App
{
    [Table("TB_APP_DICTIONARY")]
    public class XamarinAppDictionary : BaseXamarinModel
    {
        public XamarinAppDictionary()
        {
        }

        public XamarinAppDictionary(string exit, string male, string female, string languages, string namePlaceholder, int version)
        {
            Exit = exit;
            Male = male;
            Female = female;
            Languages = languages;
            NamePlaceholder = namePlaceholder;
            base.ExternalTableVersion = version;
        }

        public string Exit { get;  set; }
        public string Male { get;  set; }
        public string Female { get;  set; }
        public string Languages { get;  set; }
        public string NamePlaceholder { get;  set; }
    }
}
