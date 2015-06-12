using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCommon
{
    public class Converter
    {
        public static DateTime ConvertToDateTime(object obj, DateTime defaultValue=default(DateTime))
        {
            DateTime result;
            if ( obj != null
                && DateTime.TryParse(obj.ToString(), out result) )
                return result;

            return defaultValue;
        }

        public static int ConvertToDateTime(object obj, int defaultValue = default(int))
        {
            int result;
            if (obj != null
                && int.TryParse(obj.ToString(), out result))
                return result;

            return defaultValue;
        }

        public static T ConvertTo<T>(object obj, T defaultValue = default(T))
        {
            
            if (obj == null)
                return defaultValue;

            T result = default(T);
            object objBool = typeof(T).GetMethod("TryParse").Invoke(null, new object[]{obj.ToString(), result});
            if (Convert.ToBoolean(objBool))
                return result;

            return defaultValue;
        }
    }
}
