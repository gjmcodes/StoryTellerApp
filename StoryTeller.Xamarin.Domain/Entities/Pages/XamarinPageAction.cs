namespace StoryTeller.Xamarin.Domain.Entities.Pages
{
    public class XamarinPageAction : BaseXamarinModel
    {
        public XamarinPageAction(string pageId, string description, string pageIdToNagivate, string externalVersion)
        {
            PageId = pageId;
            Description = description;
            PageIdToNagivate = pageIdToNagivate;
            base.ExternalTableVersion = externalVersion;
        }

        public string PageId { get; private set; }
        public string Description { get; private  set; }
        public string PageIdToNagivate { get; private  set; }
    }
}
