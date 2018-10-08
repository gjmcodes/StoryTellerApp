using SQLite;
using StoryTeller.Core.Interfaces.Repositories;
using StoryTeller.Core.Models;
using StoryTeller.CrossCutting.Disposable;
using StoryTeller.InternalData.DTOs.PersistentObjects;
using StoryTeller.InternalData.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTeller.InternalData.Repositories
{
    public class BaseRepository : DisposableObject, IBaseRepository
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
      

        public BaseRepository()
        {
           
        }

        protected override void ReleaseResources()
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
    }
}
