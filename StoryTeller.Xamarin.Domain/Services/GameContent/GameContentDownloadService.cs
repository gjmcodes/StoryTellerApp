using System.Collections.Generic;
using System.Threading.Tasks;
using StoryTeller.Core.Interfaces.Repositories.External.App;
using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.External.Pronoums;
using StoryTeller.Core.Services;
using StoryTeller.Core.Services.GameContentDownload;
using StoryTeller.Xamarin.Domain.Entities.App.Repositories;
using StoryTeller.Xamarin.Domain.Entities.Pages.Repositories;
using StoryTeller.Xamarin.Domain.Entities.Pronoums.Repositories;

namespace StoryTeller.Xamarin.Domain.Services
{
    public class GameContentDownloadService : BaseService, IGameContentDownloadService
    {
        private readonly IAppDictionaryExternalRepository _appDictionaryExternalRepository;
        private readonly IAppDictionaryLocalRepository _appDictionaryLocalRepository;

        private readonly IPronoumExternalRepository _pronoumExternalRepository;
        private readonly IPronoumLocalRepository _pronoumLocalRepository;

        private readonly IPageExternalRepository _pageExternalRepository;
        private readonly IPageLocalRepository _pageLocalRepository;

        public GameContentDownloadService(
            IAppDictionaryExternalRepository appDictionaryExternalRepository,
            IAppDictionaryLocalRepository appDictionaryLocalRepository,

            IPronoumExternalRepository pronoumExternalRepository,
            IPronoumLocalRepository pronoumLocalRepository,

            IPageExternalRepository pageExternalRepository,
            IPageLocalRepository pageLocalRepository)
        {
            _appDictionaryExternalRepository = appDictionaryExternalRepository;
            _appDictionaryLocalRepository = appDictionaryLocalRepository;

            _pronoumExternalRepository = pronoumExternalRepository;
            _pronoumLocalRepository = pronoumLocalRepository;

            _pageExternalRepository = pageExternalRepository;
            _pageLocalRepository = pageLocalRepository;
        }

        public async Task<bool> DownloadAppDictionaryAsync()
        {
            var appDic = await _appDictionaryExternalRepository.GetAppDictionaryByCultureAsync();
            return await _appDictionaryLocalRepository.AddAppDictionaryAsync(appDic);
        }

        public async Task<bool> DownloadGamePagesAsync()
        {
            var gamePages = await _pageExternalRepository.GetPagesByCultureAsync();

            return await _pageLocalRepository.AddPagesAsync(gamePages);
        }

        public async Task<bool> DownloadPronoumsAsync()
        {
            var pronoums = await _pronoumExternalRepository.GetPronoumsByCultureAsync();

            return await _pronoumLocalRepository.AddPronoumsAsync(pronoums);
        }

        public int GetAmountOfTasks()
        {
            int amountExternalCalls = 3;
            int amountLocalPersistence = 3;

            return amountExternalCalls + amountLocalPersistence;
        }

        public IEnumerable<Task<bool>> GetDownloadTasks()
        {
            var tasks = new List<Task<bool>>();

            tasks.Add(DownloadAppDictionaryAsync());
            tasks.Add(DownloadGamePagesAsync());
            tasks.Add(DownloadPronoumsAsync());

            return tasks;
        }

        protected override void ReleaseResources()
        {
            _appDictionaryExternalRepository.Dispose();
            _appDictionaryLocalRepository.Dispose();
            _pageExternalRepository.Dispose();
            _pageLocalRepository.Dispose();
            _pronoumExternalRepository.Dispose();
            _pronoumLocalRepository.Dispose();

            base.ReleaseResources();
        }
    }
}
