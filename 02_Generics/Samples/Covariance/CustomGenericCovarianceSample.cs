using _02_Generics.Samples.Covariance.Inheritance;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Generics.Samples.Covariance
{
    public interface ICustomGenericInvariance<T> where T : ParentClass { }
    public class CustomGenericInvariance<T> : ICustomGenericInvariance<T> where T : ParentClass { }

    public interface ICustomGenericCovariance<out T> where T : ParentClass { }
    public class CustomGenericCovariance<T> : ICustomGenericCovariance<T> where T : ParentClass { }

    public interface ICustomGenericContravariance<in T> where T : ParentClass { }
    public class CustomGenericContravariance<T> : ICustomGenericContravariance<T> where T : ParentClass { 
    }

    public class CustomGenericCovarianceSample
    {
        public static void GenericParamMethod(ICustomGenericInvariance<ChildClass> generic) { }
        public static void GenericContravarianceParamMethod(ICustomGenericContravariance<ChildClass> generic) { }
        public static void GenericCovarianceParamMethod(ICustomGenericCovariance<ChildClass> generic) { }

        public static void CustomGenericInvarianceTest()
        {
            ICustomGenericInvariance<ChildClass> customGenericInvariance = new CustomGenericInvariance<ChildClass>();
            //ERROR
            //ICustomGenericInvariance<ChildClass> customGenericInvariance2 = new CustomGenericInvariance<ParentClass>();
            //ERROR
            //ICustomGenericInvariance<ChildClass> customGenericInvariance3 = new CustomGenericInvariance<ChildChildClass>();

            //ERROR
            //Invariant by default
            //GenericParamMethod(new CustomGenericInvariance<ParentClass>());
            GenericParamMethod(new CustomGenericInvariance<ChildClass>());
            //ERROR
            //GenericParamMethod(new CustomGenericInvariance<ChildChildClass>());
        }

        public static void CustomGenericCovarianceTest()
        {
            ICustomGenericCovariance<ChildClass> customGenericCovariance = new CustomGenericCovariance<ChildClass>();
            //ERROR
            //ICustomGenericCovariance<ChildClass> customGenericCovariance2 = new CustomGenericCovariance<ParentClass>();
            ICustomGenericCovariance<ChildClass> customGenericCovariance3 = new CustomGenericCovariance<ChildChildClass>();

            //Użycie jako argument
            GenericCovarianceParamMethod(new CustomGenericCovariance<ChildClass>());
            //ERROR
            //GenericCovarianceParamMethod(new CustomGenericCovariance<ParentClass>());
            GenericCovarianceParamMethod(new CustomGenericCovariance<ChildChildClass>());         
        }

        public static void CustomGenericContravarianceTest()
        {
            ICustomGenericContravariance<ChildClass> customGenericContravariance = new CustomGenericContravariance<ChildClass>();
            ICustomGenericContravariance<ChildClass> customGenericContravariance2 = new CustomGenericContravariance<ParentClass>();
            //ERROR
            //ICustomGenericContravariance<ChildClass> customGenericContravariance3 = new CustomGenericContravariance<ChildChildClass>();


            GenericContravarianceParamMethod(new CustomGenericContravariance<ChildClass>());
            GenericContravarianceParamMethod(new CustomGenericContravariance<ParentClass>());
            //ERROR
            //GenericContravarianceParamMethod(new CustomGenericContravariance<ChildChildClass>());
        }
    }


}
