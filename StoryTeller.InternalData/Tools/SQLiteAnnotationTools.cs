using SQLite;
using StoryTeller.InternalData.DTOs.PersistentObjects;
using System.Linq;

namespace StoryTeller.InternalData.Tools
{
    public class SQLiteAnnotationTools
    {
        public static string GetTableName<T>() where T : BasePersistentObject
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
