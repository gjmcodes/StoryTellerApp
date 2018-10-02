using StoryTeller.Core.ContentTranslation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.ContentTranslation
{
    public interface INameCallTranslatorService : IBaseService
    {
        Task<IEnumerable<ContentTranslationDto>> BreakNameCallsAsync(IEnumerable<ContentTranslationDto> paragraphedContents);
    }
}
