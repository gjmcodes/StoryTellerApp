using StoryTeller.Core.Pages;
using StoryTeller.Xamarin.Domain.Entities.Pages;
using StoryTeller.Xamarin.Domain.Entities.Pages.Factories.Interfaces;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Factories.Pages
{
    public class XamarinPageFactory : BaseFactory, IXamarinPageFactory
    {
        public async Task<XamarinPage> MapPageToXamarinPageAsync(Page page)
        {
            return await Task.Run(() =>
            {
                var xamPg = new XamarinPage(
                    page.PageId,
                    page.Title,
                    page.Image,
                    page.Version
                );

                return xamPg;
            });
        }

    }
}
