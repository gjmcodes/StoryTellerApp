using StoryTeller.Core.Pages;
using StoryTellerTemplate.Models.MainPage;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface IPageVmFactory : IBaseFactory
    {
        PageVm MapPageToPageVm(Page page);
    }
}
