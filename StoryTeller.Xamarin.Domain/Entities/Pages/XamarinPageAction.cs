namespace StoryTeller.Xamarin.Domain.Entities.Pages
{
    public class XamarinPageAction : BaseXamarinModel
    {
        public XamarinPageAction()
        {
        }

        public XamarinPageAction(string pageId, string description, string pageIdToNagivate, int externalVersion)
        {
            PageId = pageId;
            Description = description;
            PageIdToNagivate = pageIdToNagivate;
            base.ExternalTableVersion = externalVersion;
        }

        public string PageId { get; set; }
        public string Description { get; set; }
        public string PageIdToNagivate { get; set; }
    }
}
