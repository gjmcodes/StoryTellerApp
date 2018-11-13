using System.Collections.Generic;
using System.Threading.Tasks;
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

        public PageLocalRepository(
            IXamarinPageFactory xamarinPageFactory, 
            IXamarinPageActionFactory xamarinPageActionFactory, 
            IXamarinPageContentFactory xamarinPageContentFactory)
        {
            _xamarinPageFactory = xamarinPageFactory;
            _xamarinPageActionFactory = xamarinPageActionFactory;
            _xamarinPageContentFactory = xamarinPageContentFactory;
        }

        public async Task<bool> AddPagesAsync(IEnumerable<Page> entities)
        {
            await Conn.DeleteAllAsync<XamarinPage>();
            await Conn.DeleteAllAsync<XamarinPageContent>();
            await Conn.DeleteAllAsync<XamarinPageAction>();

            foreach (var item in entities)
            {
                var xamPg = await _xamarinPageFactory.MapPageToXamarinPageAsync(item);
                var xamPgContent = await _xamarinPageContentFactory.MapPageContentToXamarin(item.content.content, item.pageId, item.version);
                var xamPgActions = await _xamarinPageActionFactory.MapActionToXamarinAsync(item.actions, item.pageId, item.version);

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
    }
}
