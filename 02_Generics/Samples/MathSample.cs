using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _02_Generics.Samples
{
    public interface IMathSample<Tx, Ty, TResult>
    {
        TResult Sum(Tx x, Ty y);
        TResult Multi(Tx x, Ty y);
    }

    public class StringIntToDouble : IMathSample<string, int, double>
    {
        public double Multi(string x, int y) => (Convert.ToInt32(x) * y);

        public double Sum(string x, int y) => (Convert.ToInt32(x) + y);
    }
    public class StringIntToT<T> : IMathSample<string, int, T>
    {
        public T Multi(string x, int y)
        {
            //Terrible cast
            if (typeof(T) == typeof(string))
            {
                return (T)(object)(Convert.ToInt32(x) * y).ToString();
            }
            //Terrible cast
            return (T)(object)(Convert.ToInt32(x) * y);
        }

        public T Sum(string x, int y)
        {
            //Terrible cast
            if (typeof(T) == typeof(string))
            {
                return (T)(object)(Convert.ToInt32(x) + y).ToString();
            }

            return (T)(object)(Convert.ToInt32(x) + y);
        }
    }

    public class MathSample
    {
        public static void MathSampleTest()
        {
            var stringIntToDouble = new StringIntToDouble();
            Debug.WriteLine(stringIntToDouble.Sum("5", 10)," '5' + 10 ");
            Debug.WriteLine(stringIntToDouble.Multi("5", 10)," '5' * 10 ");

            Debug.WriteLine(new StringIntToT<string>().Sum("5", 10)," '5' + 10 to string");
            Debug.WriteLine(new StringIntToT<string>().Multi("5", 10)," '5' * 10 to string");
            Debug.WriteLine(new StringIntToT<int>().Multi("5", 10)," '5' * 10 to int");
        }
    }
}
