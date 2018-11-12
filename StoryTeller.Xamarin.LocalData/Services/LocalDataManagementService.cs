using SQLite;
using StoryTeller.Core.Services;
using StoryTeller.Xamarin.Domain.Entities.App;
using StoryTeller.Xamarin.Domain.Entities.CharactersData;
using StoryTeller.Xamarin.Domain.Entities.Pages;
using StoryTeller.Xamarin.Domain.Entities.Pronoums;
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

        public LocalDataManagementService()
        {
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
            await _conn.DeleteAllAsync<XamarinPronoum>();
            await _conn.DeleteAllAsync<XamarinPage>();
            await _conn.DeleteAllAsync<XamarinPageContent>();
            await _conn.DeleteAllAsync<XamarinPageAction>();
        }

        protected override void ReleaseResources()
        {
            _conn.Dispose();
        }

        public async Task VerifyLocalTablesUpdateFromExternalDataAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> HasLocalTablesAsync()
        {
            return await TableExistsAsync<XamarinCharacter>();
        }

        public async Task<bool> HasCharactersCreatedAsync()
        {
            var charCount = await _conn.Table<XamarinCharacter>().CountAsync();

            return charCount > 0;
        }
    }
}
