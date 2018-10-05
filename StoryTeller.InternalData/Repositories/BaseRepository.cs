using SQLite;
using StoryTeller.Core.Interfaces.Repositories;
using StoryTeller.Core.Models;
using StoryTeller.CrossCutting.Disposable;
using StoryTeller.InternalData.DTOs.PersistentObjects;
using StoryTeller.InternalData.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTeller.InternalData.Repositories
{
    public class BaseRepository<T> : DisposableObject, IBaseRepository
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
           
        }

        protected override void ReleaseResources()
        {
        }
    }
}
