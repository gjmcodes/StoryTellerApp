using StoryTeller.Core.ContentTranslation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.ContentTranslation
{
    public interface  IFontAttributeTranslatorService : IBaseService
    {
        Task<IEnumerable<ContentTranslationDto>> BreakAttributesAsync(IEnumerable<ContentTranslationDto> paragraphedContents);
    }
}
