using StoryTeller.Core.Interfaces.Repositories.External.App;
using StoryTeller.Core.Interfaces.Repositories.Local.App;
using StoryTeller.Core.Interfaces.Services.GameContentDownload;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.GameContentDownload
{
    public class AppDictionaryDownloadTasksService : BaseService, IAppDictionaryDownloadTasksService
    {
        private readonly IAppDictionaryExternalRepository _appDictionaryExternalRepository;
        private readonly IAppDictionaryLocalRepository _appDictionaryLocalRepository;

        public AppDictionaryDownloadTasksService(IAppDictionaryExternalRepository appDictionaryExternalRepository,
            IAppDictionaryLocalRepository appDictionaryLocalRepository)
        {
            _appDictionaryExternalRepository = appDictionaryExternalRepository;
            _appDictionaryLocalRepository = appDictionaryLocalRepository;
        }


        public async Task<bool> DownloadAppDictionaryByCultureAsync()
        {
            var data = await _appDictionaryExternalRepository.GetAppDictionaryByCultureAsync();

            return await _appDictionaryLocalRepository.UpdateAppDictionaryAsync(data);
        }

    }
}
