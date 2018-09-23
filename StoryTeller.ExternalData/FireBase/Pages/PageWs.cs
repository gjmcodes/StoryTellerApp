using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Pages;
using StoryTeller.CrossCutting.User.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.ExternalData.FireBase.Pages
{
    public class PageWs : BaseFirebaseWs, IPageExternalRepository
    {
        public PageWs(UserPreferences userPreferences) 
            : base("Pages", userPreferences)
        {
        }

        public async Task<Page> GetPageByIdAsync(string pageId)
        {
            var page = await base.GetByKeyWithLanguageAsync<Page>(nameof(pageId), pageId);

            return page.First();
        }

        protected override void ReleaseResources()
        {
        }
    }
}
