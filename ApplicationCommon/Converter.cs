using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

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

        public static int ConvertToInt(object obj, int defaultValue = default(int))
        {
            int result;
            if (obj != null
                && int.TryParse(obj.ToString(), out result))
                return result;

            return defaultValue;
        }

    }
}
