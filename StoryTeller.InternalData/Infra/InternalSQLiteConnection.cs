using SQLite;
using System;

namespace StoryTeller.InternalData.Infra
{
    public class InternalSQLiteConnection : SQLiteAsyncConnection, IDisposable
    {
        public InternalSQLiteConnection(string databasePath, bool storeDateTimeAsTicks = true, object key = null) : base(databasePath, storeDateTimeAsTicks, key)
        {
        }

        public InternalSQLiteConnection(string databasePath, SQLiteOpenFlags openFlags, bool storeDateTimeAsTicks = true, object key = null) : base(databasePath, openFlags, storeDateTimeAsTicks, key)
        {
        }

        public async void Dispose()
        {
            await this.CloseAsync();
        }
    }
}
