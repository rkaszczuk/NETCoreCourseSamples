using System;
using System.Collections.Generic;
using System.Text;

namespace _06_ExtensionMethods.Samples
{
    public static class ComparableExtSample
    {
        public static bool Between<T>(this T value, T lowerLimit, T upperLimit) where T : IComparable<T>
        {
            return value.CompareTo(lowerLimit) >= 0 && value.CompareTo(upperLimit) < 0;
        }
    }
}
