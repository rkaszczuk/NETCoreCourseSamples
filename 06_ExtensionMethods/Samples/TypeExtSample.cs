using System;
using System.Collections.Generic;
using System.Text;

namespace _06_ExtensionMethods.Samples
{
    public static class TypeExtSample
    {
        private static List<Type> NumericTypes = new List<Type>
        {
            typeof(byte),
            typeof(sbyte),
            typeof(ushort),
            typeof(uint),
            typeof(ulong),
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(decimal)
        };

        public static bool IsNumericType(this Type type)
        {
            return NumericTypes.Contains(type) || NumericTypes.Contains(Nullable.GetUnderlyingType(type));
        }
    }
}
