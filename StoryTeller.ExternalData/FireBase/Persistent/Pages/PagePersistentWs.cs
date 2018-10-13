using StoryTeller.Core.Interfaces.Repositories.External.Persistence.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.Users;
using StoryTeller.Core.Pages;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.Persistent.Pages
{
    public class PagePersistentWs : BaseFirebaseWs, IPageExternalPersistentRepository
    {
        public PagePersistentWs(IUserStatusLocalReadOnlyRepository userStatusLocalRepository) 
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
