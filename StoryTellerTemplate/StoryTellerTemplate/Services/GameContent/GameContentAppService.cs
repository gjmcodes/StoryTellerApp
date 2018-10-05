using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Services.Users;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Models.MainPage;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Services.GameContent
{
    public class GameContentAppService : BaseAppService, IGameContentAppService
    {
        private readonly IPageExternalRepository _pageExternalRepository;
        private readonly IUserStatusService _userStatusService;
        private readonly IPageVmFactory _pageVmFactory;

        public GameContentAppService(
            IUserStatusService userStatusService,
            IPageExternalRepository pageExternalRepository,
            IPageVmFactory pageVmFactory)
        {
            _pageExternalRepository = pageExternalRepository;
            _userStatusService = userStatusService;
            _pageVmFactory = pageVmFactory;
        }

        async Task<PageVm> GetPageAsync(string pageId)
        {
            var page = await _pageExternalRepository.GetPageByIdAsync(pageId);
            var pageVm = _pageVmFactory.MapPageToPageVm(page);

            return pageVm;
        }

        public async Task<PageVm> GetCurrentPageAsync()
        {
            var currentPageId = await _userStatusService.GetCurrentPageIdAsync();
            var vm = await GetPageAsync(currentPageId);

            return vm;
        }

        public async Task<PageVm> GetPageByIdAsync(string pageId)
        {
            var pageVm = await GetPageAsync(pageId);

            await _userStatusService.UpdateCurrentPageIdAsync(pageId);

            return pageVm;
        }
    }
}
