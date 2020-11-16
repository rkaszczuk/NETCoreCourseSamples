using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Generics.Samples
{
    //Implementacja wzorca singleton
    //Dla uproszczenia określamy że T musi mieć bezparametrowy konstruktor
    public class SingletonSample<T> where T : new()
    {
        private static T instance;
        public static T GetInstance()
        {
            //Jeżeli instancja T nie została jeszcze utworzona to ją stworzymy
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }

    public class SingletonSampleObj
    {
        public string Foo { get; set; }
    }
}
