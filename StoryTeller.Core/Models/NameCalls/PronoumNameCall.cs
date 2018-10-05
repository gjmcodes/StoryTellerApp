namespace StoryTeller.Core.Models.NameCalls
{
    public class PronoumNameCall : BaseExternalEntity
    {
        public string PronoumId { get; private set; }
        public string ForMale { get; private set; }
        public string ForFemale { get; private set; }
    }
}
