#define USE_CONEMU
using _09_Reflection.Exercises;
using _09_Reflection.Samples;
using System;
using System.Diagnostics;
using System.Linq;

namespace _09_Reflection
{
    class Program
    {
        public static int Fibonacci(int n)
        {
            if (n <= 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        static void Main(string[] args)
        {
            #region ConEMU
#if USE_CONEMU
            ProcessStartInfo pi = new ProcessStartInfo(@"C:\Program Files\ConEmu\ConEmu\ConEmuC.exe", "/AUTOATTACH");
            pi.CreateNoWindow = false;
            pi.UseShellExecute = false;
            Process.Start(pi);
#endif
            #endregion

            #region Trace to console
            //Zrzucanie Trace/Debug do konsoli
            TextWriterTraceListener consoleTraceWriter = new
                    TextWriterTraceListener(System.Console.Out);
            Trace.Listeners.Add(consoleTraceWriter);
            #endregion

            //Start code below
            //var result = ReflectionWeavingLike.RunMethodWithWrapper(() =>
            //{
            //    return Fibonacci(42);
            //});

            var attributeWrapperTest = new AttributeWrapperTest();
            //var result = AttributeWrapper.RunWithWrapper(attributeWrapperTest, "Fibonacci", new object[] { 42 });
            //Debug.WriteLine(result);

            var result = AttributeWrapper.RunWithWrapper(attributeWrapperTest, "ConcatStrings", new object[] { "Ala", " ma kota" });
            Debug.WriteLine(result);


            //ReflectionEmitDynamicMethodSample.ReflectionEmitDynamicMethodSampleTest();

            //ReflectionPropertiesPrinter.PrintObjectProperties(userType, user, "User");

            //var validator = new ValidationAttribute();
            //validator.ValidateObject(user);


            //foreach(var method in userType.GetMethods().Where(x=>x.DeclaringType == userType))
            //{
            //    Debug.WriteLine($"{method.IsSpecialName} {method.DeclaringType} -> {method.ReturnType} {method.Name}");
            //    foreach(var parameter in method.GetParameters())
            //    {
            //        Debug.Write($"{parameter.ParameterType} {parameter.Name} = {parameter.DefaultValue}, ");
            //    }
            //    Debug.WriteLine(" ");
            //    if(method.Name == "GetFullAddress")
            //    {
            //        Debug.Write(method.Invoke(user, new object[] { Type.Missing}), "Method Invoke");
            //    }

            //}




            //Type userType = typeof(User);
            //userType = user.GetType();

            //foreach(var property in userType.GetProperties())
            //{               
            //    var propertyValue = property.GetValue(user); 
            //    Debug.WriteLine($"{property.PropertyType} {property.Name} {propertyValue}", "user property");
            //    if(property.PropertyType == typeof(Address))
            //    {
            //        foreach(var addressProperty in property.PropertyType.GetProperties())
            //        {
            //            var addressPropertyValue = addressProperty.GetValue(propertyValue);
            //            Debug.WriteLine($"{addressProperty.PropertyType} {addressProperty.Name} {addressPropertyValue}", "address properties");
            //        }
            //    }
            //}

            Console.ReadKey();
        }
    }
}
