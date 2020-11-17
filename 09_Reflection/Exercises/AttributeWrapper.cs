using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace _09_Reflection.Exercises
{
    //Na podstawie interfejsu stworzyć dwa atrubuty z możliwością przypisania do metody lub klasy 
    //-MessureTimeAttribute - wypisujący czas wykonania metody
    //-NotNullParametersAttribute - zwracający exception jeżeli któryś z parametrów jest nullem
    //
    //W metodzie statycznej AttributeWrapper.RunWithWrapper(object obj, string methodName, object[] parameters) uzupełnić implementację:
    //-Pobierze informacje o metodzie na podstawie methodName
    //-Sprawdzi czy klasa lub metoda posiada atrybut typu IWrapperAttribute
    //-Jeżeli tak to przed wykonaniem metody uruchomi BeforeExecute
    //-Uruchomi metodę dla przekazanego obiektu, z przekazanymi parametrami
    //-Jeżeli metoda posiada atrybut IWrapperAttribute wykona AfterExecute z przekazanym wynikiem wykonania metody
    //-Zwróci wynik wykonania metody
    //Storzyć klase z 3 metodami: bez atrybutów, z atrybutem MessureTimeAttribute (+sleep wewnątrz), z atrybutem NotNullParametersAttribute
    public interface IWrapperAttribute
    {
        void BeforeExecute(params object[] parameters);
        void AfterExecute(object result);

    }

    public class NotNullParametersAttribute : Attribute, IWrapperAttribute
    {
        public void AfterExecute(object result)
        {
            return;
        }

        public void BeforeExecute(params object[] parameters)
        {
            foreach(var parameter in parameters)
            {
                if(parameter == null)
                {
                    throw new Exception("Jeden z parametrów jest NULL");
                }
            }
        }
    }

    public class MessureTimeAttribute : Attribute, IWrapperAttribute
    {
        private Stopwatch stopwatch;
        public void AfterExecute(object result)
        {
            Console.WriteLine($"ElapsedMilliseconds {stopwatch.ElapsedMilliseconds}");
        }
        public void BeforeExecute(params object[] parameters)
        {
            stopwatch = Stopwatch.StartNew();

        }
    }

    public class AttributeWrapper
    {
        public static object RunWithWrapper(object obj, string methodName, object[] parameters)
        {
            var methodInfo = obj.GetType().GetMethod(methodName);
            var wrapperAttributes = methodInfo.GetCustomAttributes(true)
                .Where(x => x.GetType().GetInterface("IWrapperAttribute") != null);

            foreach (var wrapperAttribute in wrapperAttributes)
            {
                var castedWrapperAttribute = (IWrapperAttribute)wrapperAttribute;
                castedWrapperAttribute.BeforeExecute(parameters);
            }
            var result = methodInfo.Invoke(obj, parameters);
            foreach (var wrapperAttribute in wrapperAttributes)
            {
                var castedWrapperAttribute = (IWrapperAttribute)wrapperAttribute;
                castedWrapperAttribute.AfterExecute(result);
            }

            return result;
        }
    }

    public class AttributeWrapperTest
    {
        [MessureTime]
        public int Fibonacci(int n)
        {
            if (n <= 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        [NotNullParameters]
        public string ConcatStrings(string s1, string s2)
        {
            return s1 + s2;
        }

    }
}
