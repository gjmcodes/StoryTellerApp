using StoryTeller.Core.ContentTranslation;
using System.Collections.Generic;

namespace StoryTeller.Core.Interfaces.Services.ContentTranslation
{
    public interface IParagraphTranslatorService : IBaseService
    {
        IEnumerable<ContentTranslationDto> BreakIntoParagraphs(string content);
    }
}
