using SQLite;
using StoryTeller.Core.Interfaces.Repositories.External.App;
using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.External.Pronoums;
using StoryTeller.Core.Services;
using StoryTeller.Core.Services.GameContentDownload;
using StoryTeller.Xamarin.Domain.Entities.App;
using StoryTeller.Xamarin.Domain.Entities.App.Repositories;
using StoryTeller.Xamarin.Domain.Entities.CharactersData;
using StoryTeller.Xamarin.Domain.Entities.Pages;
using StoryTeller.Xamarin.Domain.Entities.Pages.Repositories;
using StoryTeller.Xamarin.Domain.Entities.Pronoums;
using StoryTeller.Xamarin.Domain.Entities.Pronoums.Repositories;
using StoryTeller.Xamarin.Domain.Interfaces.Services.LocalData;
using StoryTeller.Xamarin.LocalData.SQLite;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTeller.Xamarin.LocalData.Services
{
    public class LocalDataManagementService : BaseService, ILocalDataManagementService
    {
        private readonly LocalSQLiteConnection _conn;

        private readonly IAppDictionaryLocalRepository _appDictionaryLocalRepository;
        private readonly IPageLocalRepository _pageLocalRepository;
        private readonly IPronoumLocalRepository _pronoumLocalRepository;

        private readonly IAppUpdateExternalRepository _appUpdateExternalRepository;

        private readonly IGameContentDownloadService _gameContentDownloadService;

        public LocalDataManagementService(
            IAppDictionaryLocalRepository appDictionaryLocalRepository, 
            IPageLocalRepository pageLocalRepository, 
            IPronoumLocalRepository pronoumLocalRepository, 
            IAppUpdateExternalRepository appUpdateExternalRepository, 
            IGameContentDownloadService gameContentDownloadService)
        {
            _appDictionaryLocalRepository = appDictionaryLocalRepository;
            _pageLocalRepository = pageLocalRepository;
            _pronoumLocalRepository = pronoumLocalRepository;
            _appUpdateExternalRepository = appUpdateExternalRepository;
            _gameContentDownloadService = gameContentDownloadService;

            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        async Task<bool> TableExistsAsync<T>() where T : class
        {
            var tableName = SQLiteAnnotationTools.GetTableName<T>();

            var sql = $@"SELECT name FROM sqlite_master WHERE type = 'table' AND name = '{tableName}'";
            var tableMapping = new TableMapping(typeof(SqlDbType));
            var query = await _conn.QueryAsync(tableMapping, sql);

            return query.Any();
        }

        public async Task CreateLocalTablesAsync()
        {
            await _conn.CreateTableAsync<XamarinCharacter>();

            await _conn.CreateTableAsync<XamarinPronoum>();

            await _conn.CreateTableAsync<XamarinPage>();
            await _conn.CreateTableAsync<XamarinPageContent>();
            await _conn.CreateTableAsync<XamarinPageAction>();

            await _conn.CreateTableAsync<XamarinAppDictionary>();
            await _conn.CreateTableAsync<XamarinUserSettings>();
            await _conn.CreateTableAsync<XamarinUserCharacterData>();
        }

        public async Task ClearLocalDataForCulctureChangeAsync()
        {
            await _conn.DeleteAllAsync<XamarinAppDictionary>();
            await _conn.DeleteAllAsync<XamarinPronoum>();
            await _conn.DeleteAllAsync<XamarinPage>();
            await _conn.DeleteAllAsync<XamarinPageContent>();
            await _conn.DeleteAllAsync<XamarinPageAction>();
        }

     

        public async Task VerifyLocalTablesUpdateFromExternalDataAsync()
        {
            var appDictionaryVersionTask = _appDictionaryLocalRepository.GetVersionAsync();
            var pagesVersionTask = _pageLocalRepository.GetVersionAsync();
            var pronoumsVersionTask = _pronoumLocalRepository.GetVersionAsync();

            var externalAppDictionaryVersionTask = _appUpdateExternalRepository.GetAppDictionaryCurrentVersionByCultureAsync();
            var externalPageVersionTask = _appUpdateExternalRepository.GetPagesCurrentVersionByCultureAsync();
            var externalPronoumVersionTask = _appUpdateExternalRepository.GetPronoumCurrentVersionByCultureAsync();


            await Task.WhenAll(
                appDictionaryVersionTask, pagesVersionTask, pronoumsVersionTask,
                externalAppDictionaryVersionTask, externalPageVersionTask, externalPronoumVersionTask);

            if (appDictionaryVersionTask.Result < externalAppDictionaryVersionTask.Result.version)
            {
                await _conn.DeleteAllAsync<XamarinAppDictionary>();
                await _gameContentDownloadService.DownloadAppDictionaryAsync();
            }

            if (pagesVersionTask.Result < externalPageVersionTask.Result.version)
            {
                await _conn.DeleteAllAsync<XamarinPage>();
                await _conn.DeleteAllAsync<XamarinPageContent>();
                await _conn.DeleteAllAsync<XamarinPageAction>();

                await _gameContentDownloadService.DownloadGamePagesAsync();
            }

            if (pronoumsVersionTask.Result < externalPageVersionTask.Result.version)
            {
                await _conn.DeleteAllAsync<XamarinPronoum>();

                await _gameContentDownloadService.DownloadPronoumsAsync();
            }
        }

        public async Task<bool> HasLocalTablesAsync()
        {
            return await TableExistsAsync<XamarinCharacter>();
        }

        public async Task<bool> HasCultureSelectedAsync()
        {
            var userSettings = await _conn.Table<XamarinUserSettings>().FirstAsync();

            return string.IsNullOrEmpty(userSettings.SelectedCulture);
        }

        public async Task<bool> HasCharactersCreatedAsync()
        {
            var charCount = await _conn.Table<XamarinCharacter>().CountAsync();

            return charCount > 0;
        }

        protected override void ReleaseResources()
        {
            _conn.Dispose();
            _appDictionaryLocalRepository.Dispose();
            _appUpdateExternalRepository.Dispose();
            _gameContentDownloadService.Dispose();
            _pageLocalRepository.Dispose();
            _pronoumLocalRepository.Dispose();
        }
    }
}
