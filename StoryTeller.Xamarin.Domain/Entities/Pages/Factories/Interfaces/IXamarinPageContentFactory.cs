using StoryTeller.Core.Disposing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.Pages.Factories.Interfaces
{
    public interface IXamarinPageContentFactory : IDisposableObject
    {
        Task<IEnumerable<XamarinPageContent>> MapPageContentToXamarin(string pageContent, string pageId, int pageVersion);
    }
}
