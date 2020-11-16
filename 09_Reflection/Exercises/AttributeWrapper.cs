using System;
using System.Collections.Generic;
using System.Text;

namespace _09_Reflection.Exercises
{
    //Na podstawie interfejsu stworzyć dwa atrubuty z możliwością przypisania do metody lub klasy 
    //-MessureTimeAttribute - wypisujący czas wykonania metody
    //-NotNullParametersAttribute - zwracający exception jeżeli któryś z parametrów jest nullem
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

    public class AttributeWrapper
    {
        public static object RunWithWrapper(object obj, string methodName, object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
