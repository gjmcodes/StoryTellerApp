using StoryTeller.Core.Models.Pages.DTOs;
using StoryTeller.Core.Pages;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTellerTemplate.Models.MainPage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface IPageVmFactory : IBaseFactory
    {
        PageVm MapPageToPageVm(Page page);
        Task<PageVm> MapTranslatedPageDtoToPageVmAsync(TranslatedPageDto translatedPageDto);
        Task<PageVm> MapDtoToPageVmAsync(PageDto dto, IEnumerable<PageActionDto> pageActions, IEnumerable<PageContentDto> pageContent);
    }
}
