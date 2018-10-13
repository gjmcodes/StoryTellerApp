using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.Pages;
using StoryTeller.Core.Interfaces.Services.GameContentDownload;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.GameContentDownload
{
    public class PageDownloadTasksService : BaseService, IPageDownloadTasksService
    {
        private readonly IPageLocalRepository _pageLocalPersistentRepository;
        private readonly IPageExternalRepository _pageExternalRepository;

        public PageDownloadTasksService(IPageLocalRepository pageLocalPersistentRepository, 
            IPageExternalRepository pageExternalRepository)
        {
            _pageLocalPersistentRepository = pageLocalPersistentRepository;
            _pageExternalRepository = pageExternalRepository;
        }

        public async Task<bool> DownloadPagesByCultureAsync(string culture)
        {
            var pages = await _pageExternalRepository.GetPagesByCultureAsync(culture);
            var result = await _pageLocalPersistentRepository.AddAsync(pages);

            return result;
        }
    }
}
