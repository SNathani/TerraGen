using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.Json;
using System.Collections;

namespace TerraGen.Extensions
{
    public static class GenericExtensions
    {
        public static void ForEach<T>(this IEnumerable collection, Action<T> action)
        {
            lock (collection)
            {
                foreach (T item in collection)
                    action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection != null && collection.Count() > 0 && action != null)
            {
                foreach (T item in collection)
                {
                    action(item);
                }
            }
        }

        public static string ToJSON(this object value)
        {
            string result = string.Empty;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            result = JsonSerializer.Serialize(value, options);

            return result;
        }

        public static T FromJSON<T>(this string value)
            where T : class, new()
        {
            T result = (T)JsonSerializer.Deserialize(value, typeof(T));
            return result;
        }

    }
}
