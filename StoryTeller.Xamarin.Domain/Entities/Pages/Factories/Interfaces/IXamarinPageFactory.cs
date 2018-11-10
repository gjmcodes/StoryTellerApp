using StoryTeller.Core.Disposing;
using StoryTeller.Core.Pages;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.Pages.Factories.Interfaces
{
    public interface IXamarinPageFactory : IDisposableObject
    {
        Task<XamarinPage> MapPageToXamarinPageAsync(Page page);
    }
}
