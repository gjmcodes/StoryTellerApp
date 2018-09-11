using System.Collections.Generic;
using System.Threading.Tasks;
using StoryTeller.Core.Interfaces.Services;
using StoryTeller.Core.Services;
using StoryTellerTemplate.Factories;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Interfaces.Services;
using Xamarin.Forms;

namespace StoryTellerTemplate.Services.Pages
{
    public class PaginationAppService : IPaginationAppService
    {
        private readonly IPaginationService _paginationService;
        private readonly ITextSpanFactory _textSpanFactory;

        public PaginationAppService()
        {
            _textSpanFactory = new TextSpanFactory();
        }

        public async Task<IEnumerable<Span>> GetCurrentPageContentTextSpansAsync()
        {
            var textSpans = await _paginationService.GetCurrentPageTextSpansAsync();
            var spans = _textSpanFactory.MapTextSpanToXamarinSpan(textSpans);

            return spans;
        }
    }
}
