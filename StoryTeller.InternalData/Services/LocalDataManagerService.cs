using SQLite;
using StoryTeller.CrossCutting.Disposable;
using StoryTeller.InternalData.DTOs.PersistentObjects;
using StoryTeller.InternalData.DTOs.PersistentObjects.App;
using StoryTeller.InternalData.DTOs.PersistentObjects.CharactersData;
using StoryTeller.InternalData.DTOs.PersistentObjects.NameCalls;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTeller.InternalData.DTOs.PersistentObjects.Users;
using StoryTeller.InternalData.Infra;
using StoryTeller.InternalData.Interfaces;
using StoryTeller.InternalData.Interfaces.Services;
using StoryTeller.InternalData.Tools;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTeller.InternalData.Services
{
    public class LocalDataManagerService : DisposableObject, ILocalDataManagerService
    {
        private readonly InternalSQLiteConnection _conn;

        public LocalDataManagerService()
        {
            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        async Task<bool> TableExists<T>() where T : BasePersistentObject
        {
            var tableName = SQLiteAnnotationTools.GetTableName<T>();

            var sql = $@"SELECT name FROM sqlite_master WHERE type = 'table' AND name = '{tableName}'";
            var tableMapping = new TableMapping(typeof(SqlDbType));
            var query = await _conn.QueryAsync(tableMapping, sql);

            return query.Any();
        }

        public async Task UpdateCreateLocalTablesAsync()
        {
            var characterTableExists = await TableExists<CharacterDto>();
            await _conn.CreateTableAsync<CharacterDto>();
            await _conn.CreateTableAsync<PronoumNameCallDto>();
            await _conn.CreateTableAsync<PageDto>();
            await _conn.CreateTableAsync<PageContentDto>();
            await _conn.CreateTableAsync<PageActionDto>();
            await _conn.CreateTableAsync<UserStatusDto>();
            await _conn.CreateTableAsync<AppDictionaryDto>();
        }

        public async Task ClearLocalDataForCulctureChangeAsync()
        {
            await _conn.DeleteAllAsync<PronoumNameCallDto>();
            await _conn.DeleteAllAsync<PageDto>();
            await _conn.DeleteAllAsync<PageContentDto>();
            await _conn.DeleteAllAsync<PageActionDto>();
        }
        protected override void ReleaseResources()
        {
            _conn.Dispose();
        }
    }
}
