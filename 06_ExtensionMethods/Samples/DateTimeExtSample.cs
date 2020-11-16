using System;
using System.Collections.Generic;
using System.Text;

namespace _06_ExtensionMethods.Samples
{
    public static class DateTimeExtSample
    {
        public static string ToYYYYMMDD_HHMMSS(this DateTime value)
        {
            return value.ToString("yyyyMMdd_HHmmss");
        }
    }
}
