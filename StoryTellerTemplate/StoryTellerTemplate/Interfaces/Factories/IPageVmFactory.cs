using StoryTeller.Core.Models.Pages.DTOs;
using StoryTeller.Core.Pages;
using StoryTeller.Xamarin.Domain.Entities.Pages;
using StoryTellerTemplate.Models.MainPage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface IPageVmFactory : IBaseFactory
    {
        PageVm MapPageToPageVm(XamarinPage page);
        Task<PageVm> MapTranslatedPageDtoToPageVmAsync(XamarinPage translatedPageDto);
        Task<PageVm> MapPageToPageVmAsync(XamarinPage page, IEnumerable<XamarinPageAction> pageActions, IEnumerable<XamarinPageContent> pageContent);
    }
}
