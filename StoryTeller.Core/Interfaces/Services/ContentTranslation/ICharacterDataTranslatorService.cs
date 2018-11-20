using StoryTeller.Core.ContentTranslation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.ContentTranslation
{
    public interface ICharacterDataTranslatorService : IBaseService
    {
        bool HasCharacterDataMarkers(string content);
        Task<IEnumerable<ContentTranslationDto>> BreakCharacterDataAsync(IEnumerable<ContentTranslationDto> paragraphedContents);
        Task<string> TranslateCharacterDataAsync(string content);
    }
}
