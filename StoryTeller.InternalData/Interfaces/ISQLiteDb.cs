using StoryTeller.InternalData.Infra;

namespace StoryTeller.InternalData.Interfaces
{
    public interface ISQLiteDb
    {
        InternalSQLiteConnection GetConnection();
    }
}
