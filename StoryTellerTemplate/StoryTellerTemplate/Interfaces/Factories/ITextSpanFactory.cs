using StoryTeller.Core.Text;
using StoryTeller.Xamarin.Domain.Entities.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface ITextSpanFactory : IBaseFactory
    {
        Task<IEnumerable<Span>> MapContentToSpanAsync(IEnumerable<XamarinPageContent> pageContent);
    }
}
