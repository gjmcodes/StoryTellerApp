﻿using SQLite;
using System;

namespace StoryTeller.Xamarin.LocalData.SQLite
{
    public class LocalSQLiteConnection : SQLiteAsyncConnection
    {
        public LocalSQLiteConnection(string databasePath, bool storeDateTimeAsTicks = true, object key = null) : base(databasePath, storeDateTimeAsTicks, key)
        {
        }

        public LocalSQLiteConnection(string databasePath, SQLiteOpenFlags openFlags, bool storeDateTimeAsTicks = true, object key = null) : base(databasePath, openFlags, storeDateTimeAsTicks, key)
        {
        }
    }
}
