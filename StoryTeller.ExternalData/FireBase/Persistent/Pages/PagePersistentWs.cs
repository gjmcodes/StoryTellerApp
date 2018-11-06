using StoryTeller.Core.Interfaces.Repositories.External.Persistence.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Pages;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.Persistent.Pages
{
    public class PagePersistentWs : BaseFirebaseWs, IPageExternalRepository
    {
        public PagePersistentWs(IUserStatusLocalRepository userStatusLocalRepository) 
            : base("Pages", userStatusLocalRepository)
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
