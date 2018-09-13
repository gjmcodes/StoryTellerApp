using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoryTeller.InternalData.Interfaces
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
