using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Generics.Samples
{
    //Wskazanie parametru generycznego może następować w ramach klasy lub w ramach metody
    public class FactorySample<T> where T : new()
    {
        public T Create()
        {
            return new T();
        }
    }
    public class FactorySample
    {
        public T Create<T>() where T : new()
        {
            return new T();
        }
    }

    public static class FactoryStaticSample
    {
        public static T Create<T>() where T : new()
        {
            return new T();
        }
    }
    public static class FactoryStaticSample<T> where T : new()
    {
        public static T Create() 
        {
            return new T();
        }
    }
}
