using StoryTeller.Core.Interfaces.Repositories.External.Persistence.Pages;
using StoryTeller.Core.Pages;
using StoryTeller.CrossCutting.User.Preferences;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.Persistent.Pages
{
    public class PagePersistentWs : BaseFirebaseWs, IPageExternalPersistentRepository
    {
        public PagePersistentWs(UserPreferences userPreferences) 
            : base("Pages", userPreferences)
        {
        }

        public async Task CreatePageAsync(Page page, string culture)
        {
            await base.CreateAsync<Page>(page, culture);
        }

        protected override void ReleaseResources()
        {
        }
    }
}
