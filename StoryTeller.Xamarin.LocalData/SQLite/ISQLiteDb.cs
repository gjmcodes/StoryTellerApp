namespace StoryTeller.Xamarin.LocalData.SQLite
{
    public interface ISQLiteDb
    {
        LocalSQLiteConnection GetConnection();
    }
}
