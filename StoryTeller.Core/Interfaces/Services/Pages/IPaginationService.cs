using StoryTeller.Core.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services
{
    public interface IPaginationService
    {
        Task<IEnumerable<TextSpan>> GetCurrentPageTextSpansAsync();
    }
}
