using StoryTeller.Core.ContentTranslation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.ContentTranslation
{
    public interface ICharacterDataTranslatorService : IBaseService
    {
        Task<IEnumerable<ContentTranslationDto>> BreakCharacterDataAsync(IEnumerable<ContentTranslationDto> paragraphedContents);
    }
}
