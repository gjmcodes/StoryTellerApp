using SQLite;

namespace StoryTeller.Xamarin.Domain.Entities.Pronoums
{
    [Table("TB_PRONOUMS")]
    public class XamarinPronoum : BaseXamarinModel
    {
        public XamarinPronoum()
        {
        }

        public XamarinPronoum(string pronoumId, string forMale, string forFemale)
        {
            PronoumId = pronoumId;
            ForMale = forMale;
            ForFemale = forFemale;
        }

        public string PronoumId { get; private set; }
        public string ForMale { get; private set; }
        public string ForFemale { get; private set; }
    }
}
