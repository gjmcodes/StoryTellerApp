using StoryTeller.Core.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.ContentTranslation
{
    public interface IContentMarkupTranslatorService : IBaseService
    {
        Task<IEnumerable<TextSpan>> TranslateAsync(string content);
    }
}
