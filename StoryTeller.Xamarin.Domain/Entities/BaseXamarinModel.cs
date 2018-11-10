using SQLite;
using StoryTeller.Core.Models;

namespace StoryTeller.Xamarin.Domain.Entities
{
    public class BaseXamarinModel
    {
        [PrimaryKey, AutoIncrement]
        public int LocalPk { get; set; }

        public string ExternalTableVersion { get; set; }
    }
}
