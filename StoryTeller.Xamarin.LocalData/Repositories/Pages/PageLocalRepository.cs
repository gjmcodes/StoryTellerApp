using System.Collections.Generic;
using System.Threading.Tasks;
using StoryTeller.Core.Interfaces.Repositories.External.App;
using StoryTeller.Core.Pages;
using StoryTeller.Xamarin.Domain.Entities.Pages;
using StoryTeller.Xamarin.Domain.Entities.Pages.Factories.Interfaces;
using StoryTeller.Xamarin.Domain.Entities.Pages.Repositories;

namespace StoryTeller.Xamarin.LocalData.Repositories.Pages
{
    public class PageLocalRepository : BaseRepository, IPageLocalRepository
    {
        private readonly IXamarinPageFactory _xamarinPageFactory;
        private readonly IXamarinPageActionFactory _xamarinPageActionFactory;
        private readonly IXamarinPageContentFactory _xamarinPageContentFactory;
        private readonly IAppUpdateExternalRepository _appUpdateExternalRepository;

        public PageLocalRepository(
            IXamarinPageFactory xamarinPageFactory, 
            IXamarinPageActionFactory xamarinPageActionFactory, 
            IXamarinPageContentFactory xamarinPageContentFactory,
            IAppUpdateExternalRepository appUpdateExternalRepository)
        {
            _xamarinPageFactory = xamarinPageFactory;
            _xamarinPageActionFactory = xamarinPageActionFactory;
            _xamarinPageContentFactory = xamarinPageContentFactory;
            _appUpdateExternalRepository = appUpdateExternalRepository;
        }

        public async Task<bool> AddPagesAsync(IEnumerable<Page> entities)
        {
            await Conn.DeleteAllAsync<XamarinPage>();
            await Conn.DeleteAllAsync<XamarinPageContent>();
            await Conn.DeleteAllAsync<XamarinPageAction>();

            var pagesVersion = await _appUpdateExternalRepository.GetPagesCurrentVersionByCultureAsync();

            foreach (var item in entities)
            {
                var xamPg = await _xamarinPageFactory.MapPageToXamarinPageAsync(item, pagesVersion.version);
                var xamPgContent = await _xamarinPageContentFactory.MapPageContentToXamarin(item.content.content, item.pageId, pagesVersion.version);
                var xamPgActions = await _xamarinPageActionFactory.MapActionToXamarinAsync(item.actions, item.pageId, pagesVersion.version);

                await Conn.InsertAsync(xamPg);
                await Conn.InsertAllAsync(xamPgContent);
                await Conn.InsertAllAsync(xamPgActions);
            }

            return true;
        }

        public async Task<XamarinPage> GetPageByIdAsync(string pageId)
        {
            var xamPg = await Conn.Table<XamarinPage>().FirstAsync(x => x.PageId == pageId);
            var xamPgActions = await Conn.Table<XamarinPageAction>().Where(x => x.PageId == pageId).ToListAsync();
            var xamPgContent = await Conn.Table<XamarinPageContent>().Where(x => x.PageId == pageId).ToListAsync();

            xamPg.PageActions = xamPgActions;
            xamPg.PageContent = xamPgContent;

            return xamPg;
        }

        public async Task<int> GetVersionAsync()
        {
            var xamPage = await Conn.Table<XamarinPage>().FirstAsync();

            return xamPage.ExternalTableVersion;
        }

        protected override void ReleaseResources()
        {
            _appUpdateExternalRepository.Dispose();
            _xamarinPageActionFactory.Dispose();
            _xamarinPageContentFactory.Dispose();
            _xamarinPageFactory.Dispose();
            
            base.ReleaseResources();
        }
    }
}
