using SQLite;
using StoryTeller.Xamarin.Domain.Entities;
using System.Linq;

namespace StoryTeller.Xamarin.LocalData.SQLite
{
    public class SQLiteAnnotationTools
    {
        public static string GetTableName<T>() where T : class
        {
            string tableName = string.Empty;
            var customAttributes = typeof(T).GetCustomAttributes(typeof(TableAttribute), false);
            if (customAttributes.Count() > 0)
            {
                tableName = (customAttributes.First() as TableAttribute).Name;
            }

            return tableName;
        }
    }
}
