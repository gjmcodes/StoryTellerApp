using SQLite;
using StoryTeller.CrossCutting.Disposable;
using StoryTeller.InternalData.Interfaces;
using System;
using Xamarin.Forms;

namespace StoryTeller.InternalData.Repositories
{
    public class BaseRepository<T> : DisposableObject, IBaseRepository<T> where T : new()
    {
        SQLiteAsyncConnection _conn;
        protected SQLiteAsyncConnection Conn
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

        protected AsyncTableQuery<T> tableSet;

      

        public BaseRepository()
        {
            try
            {
                Conn.CreateTableAsync<T>().Wait();

                tableSet = Conn.Table<T>();
            }
            catch (Exception e)
            {
                var t = e.Message;
                throw;
            }
        }

        protected override void ReleaseResources()
        {
        }
    }
}
