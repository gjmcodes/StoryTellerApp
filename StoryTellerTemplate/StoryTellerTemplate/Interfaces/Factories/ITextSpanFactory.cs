using StoryTeller.Core.Text;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface ITextSpanFactory : IBaseFactory
    {
        Task<IEnumerable<Span>> MapContentDtoToSpanAsync(IEnumerable<PageContentDto> pageContentDtos);
        IEnumerable<Span> MapTextSpanToXamarinSpan(IEnumerable<TextSpan> textSpan);
    }
}
