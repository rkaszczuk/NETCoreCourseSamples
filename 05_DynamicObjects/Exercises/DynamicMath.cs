using System;
using System.Collections.Generic;
using System.Text;

namespace _05_DynamicObjects.Exercises
{
    //Należy stworzyć klasę obsługującą podstawowe operacje matematyczne (dodawanie, odejmowanie, mnożenie, dzielenie)
    //w oparciu w typ dynamic
    //Przetestować działanie z użyciem różnych typów numerycznych (int, double, decimal)
    public class DynamicMath
    {
        public dynamic Sum(dynamic x, dynamic y)
        {
            return x + y;
        }
        public dynamic Sub(dynamic x, dynamic y)
        {
            return x - y;
        }
        public dynamic Multi(dynamic x, dynamic y)
        {
            return x * y;
        }
        public dynamic Div(dynamic x, dynamic y)
        {
            return x / y;
        }
    }
}
