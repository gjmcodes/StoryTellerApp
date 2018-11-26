using StoryTeller.Core.Disposing;
using StoryTeller.Core.Interfaces.Repositories;
using StoryTeller.Xamarin.Domain.Entities;
using StoryTeller.Xamarin.LocalData.SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTeller.Xamarin.LocalData.Repositories
{
    public class BaseRepository : DisposableObject, IBaseRepository
    {
        LocalSQLiteConnection _conn;
        protected LocalSQLiteConnection Conn
        {
            get
            {
                if (_conn == null)
                {
                    _conn = DependencyService.Get<ISQLiteDb>().GetConnection();
                }

                return _conn;
            }
        }

        protected string TableName<T>() where T : class
            => SQLiteAnnotationTools.GetTableName<T>();

        public BaseRepository()
        {

        }

        public async virtual Task<bool> AddAsync<T>(T entity) where T : class
        {
            return await Conn.InsertAsync(entity) > 0;
        }

        public async virtual Task<bool> AddAsync<T>(IEnumerable<T> entities) where T : class
        {
            return await Conn.InsertAllAsync(entities) > 0;
        }

        public async virtual Task<bool> UpdateAsync<T>(T entity) where T : class
        {
            return await Conn.UpdateAsync(entity) > 0;
        }

        protected override void ReleaseResources()
        {

        }
    }
}
