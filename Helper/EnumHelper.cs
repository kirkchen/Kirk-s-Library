
using System;
using System.Linq;
using System.Collections.Generic;

namespace KirkChen.Library.Helper
{
    /// <summary>
    /// EnumHelper
    /// </summary>
    public sealed class EnumHelper
    {
        public static Dictionary<string,string> GetEnumDataSource<T>(Func<T,string> key,Func<T,string> value)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            Type enumType = typeof(T);

            foreach (T item in Enum.GetValues(enumType))
            {
                keyValuePairs.Add(key(item), value(item));
            }

            return keyValuePairs;
        }
    }
}
