using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.Pages;
using StoryTeller.Core.Text;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Interfaces.Factories.Pages
{
    public interface IPageContentPersistenceFactory : IBaseLocalDataFactory
    {
        Task<IEnumerable<PageContentDto>> MapPageContentToDtoAsync(IEnumerable<TextSpan> pageContent, string pageId);
        Task<IEnumerable<ContentTranslationDto>> MapDtoToTranslatedContentAsync(IEnumerable<PageContentDto> contents);
        Task<IEnumerable<TextSpan>> MapPageContentDtoToTextSpanAsync(IEnumerable<PageContentDto> pageContentDtos);
    }
}
