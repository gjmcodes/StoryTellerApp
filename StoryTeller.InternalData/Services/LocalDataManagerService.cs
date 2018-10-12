using StoryTeller.CrossCutting.Disposable;
using StoryTeller.InternalData.DTOs.PersistentObjects.CharactersData;
using StoryTeller.InternalData.DTOs.PersistentObjects.NameCalls;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTeller.InternalData.DTOs.PersistentObjects.Users;
using StoryTeller.InternalData.Infra;
using StoryTeller.InternalData.Interfaces;
using StoryTeller.InternalData.Interfaces.Services;
using System;
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

        public async Task CreateLocalTablesAsync()
        {
            await _conn.CreateTableAsync<CharacterDto>();
            await _conn.CreateTableAsync<PronoumNameCallDto>();
            await _conn.CreateTableAsync<PageDto>();
            await _conn.CreateTableAsync<PageContentDto>();
            await _conn.CreateTableAsync<PageActionDto>();
            await _conn.CreateTableAsync<UserStatusDto>();
        }

        protected override void ReleaseResources()
        {
            _conn.Dispose();
        }
    }
}
