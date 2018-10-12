using StoryTeller.Core.Interfaces.Repositories;
using StoryTeller.CrossCutting.Disposable;
using StoryTeller.InternalData.Infra;
using StoryTeller.InternalData.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTeller.InternalData.Repositories
{
    public class BaseRepository : DisposableObject, IBaseRepository
    {
        InternalSQLiteConnection _conn;
        protected InternalSQLiteConnection Conn
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
      

        public BaseRepository()
        {
           
        }

     

        public async Task<bool> AddAsync<T>(T entity) where T : class
        {
            return await Conn.InsertAsync(entity) > 0;
        }

        public async Task<bool> AddAsync<T>(IEnumerable<T> entities) where T : class
        {
            return await Conn.InsertAllAsync(entities) > 0;
        }

        public async Task<bool> UpdateAsync<T>(T entity) where T : class
        {
            return await Conn.UpdateAsync(entity) > 0;
        }

        protected override void ReleaseResources()
        {
            _conn.Dispose();
        }
    }
}
