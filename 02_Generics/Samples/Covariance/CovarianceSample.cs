using _02_Generics.Samples.Covariance.Inheritance;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Generics.Samples.Covariance
{
    public class CovarianceSample
    {
        //Kowariancja zmiennych
        public static void VariableCovariance()
        {
           
            //Pod typ bardziej ogólny możey przypisać typ bardziej szczegółowy
            ParentClass parentObj;
            parentObj = new ChildClass();
            parentObj = new ChildChildClass();

            //Pod typ bardziej szczegółowy nie możemy przypisać typu bardziej ogólnego
            ChildClass childClass;
            //ERROR!
            //childClass = new ParentClass();
            childClass = new ChildChildClass();
        }

        //Inwariancja listy
        public static void ListInvariance()
        {
            List<ParentClass> parentList;
            //ERROR
            //parentList = new List<ChildClass>();

            List<ChildClass> childList;
            //ERROR
            //childList = new List<ParentClass>();
        }

        //Kowariancja IEnumerable
        public static void IEnumerableCovariance()
        {
            //Definicja IEnumerable:
            //public interface IEnumerable<out T> : IEnumerable

            IEnumerable<ParentClass> parentList;
            parentList = new List<ChildClass>();

            IEnumerable<ChildClass> childList;
            //ERROR
            //childList = new List<ParentClass>();
        }

        //Kontrwariancja Action
        public static void ActionContravariance()
        {
            //Definicja Action<T>
            //public delegate void Action<in T>(T obj);

            Action<ParentClass> parentAction;
            parentAction = (x) => { };

            Action<ChildClass> childAction;
            childAction = (x) => { };

            Action<ChildChildClass> childChildAction;
            childChildAction = (x) => { };

            //Jako Action<ChildClass> można przekazać typ bardziej ogólny
            ActionParamMethod(parentAction);
            ActionParamMethod(childAction);

            //Jako Action<ChildClass> nie można przekazać typu bardziej szczegółowego
            //ERROR!
            //ActionParamMethod(childChildAction);
        }
        public static void ActionParamMethod(Action<ChildClass> action) { }
    }
}
