using System;
using System.IO;
using SQLite;
using StoryTeller.InternalData.Infra;
using StoryTeller.InternalData.Interfaces;
using StoryTellerTemplate.Droid.SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace StoryTellerTemplate.Droid.SQLite
{
    public class SQLiteDb : ISQLiteDb
    {
        public InternalSQLiteConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "StoryTellerTemplateDB.db3");

            return new InternalSQLiteConnection(path);
        }
    }
}



/*
 *  --------- IOS --------- 
 * 
 * [assembly: Dependency(typeof(SQLiteDb))]
namespace StudentLoungeApp.iOS.SQLite
{

    public class SQLiteDb : ISQLiteDb
    {

        public SQLiteAsyncConnection GetConnection()
        {
            var filename = "StoryTellerTemplateDB.db3";

            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            var path = Path.Combine(libFolder, filename);

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
                return new SQLiteAsyncConnection(path);
            }

            return new SQLiteAsyncConnection(path);
        }
    }
}
 */
