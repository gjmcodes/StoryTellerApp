using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTellerTemplate.Interfaces.Services
{
    public interface IPaginationAppService
    {
        Task<IEnumerable<Span>> GetCurrentPageContentTextSpansAsync();
    }
}
