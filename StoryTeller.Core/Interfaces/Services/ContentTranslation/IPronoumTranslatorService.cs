using StoryTeller.Core.ContentTranslation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.ContentTranslation
{
    public interface IPronoumTranslatorService : IBaseService
    {
        Task<string> TranslatePronoumAsync(string content);
        bool HasPronoumMarkers(string content);
        Task<IEnumerable<ContentTranslationDto>> BreakNameCallsAsync(IEnumerable<ContentTranslationDto> paragraphedContents);
    }
}
