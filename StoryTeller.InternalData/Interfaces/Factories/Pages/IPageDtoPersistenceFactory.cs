using StoryTeller.Core.Models.Pages.DTOs;
using StoryTeller.Core.Pages;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Interfaces.Factories.Pages
{
    public interface IPageDtoPersistenceFactory 
    {
        Task<PageDto> MapPageToDtoAsync(Page pages);
        Task<IEnumerable<PageDto>> MapPageToDtoAsync(IEnumerable<Page> pages);
        Task<TranslatedPageDto> MapPageDtoToTranslatedAsync(PageDto pageDto, IEnumerable<PageActionDto> pageActions, IEnumerable<PageContentDto> pageContents);
    }
}
