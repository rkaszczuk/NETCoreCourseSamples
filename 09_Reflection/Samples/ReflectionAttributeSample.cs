using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Reflection;

namespace _09_Reflection.Samples
{
    public class AllowPrintAttribute : Attribute
    {
        public bool IsAllowPrint { get; set; }
        public AllowPrintAttribute(bool isAllowPrint)
        {
            IsAllowPrint = isAllowPrint;
        }
    }
    public class ConvertToStringAttribute : Attribute
    {
        public Func<object, string> ConvertFunc { get; set; }
        public ConvertToStringAttribute(Func<object, string> convertFunc)
        {
            ConvertFunc = convertFunc;
        }
    }
    //Atrybut może być przypięty tylko do metody
    [AttributeUsage(AttributeTargets.Method)]
    public class LogMethodOutputAttribute : Attribute
    {
        public void Log(object methodResult)
        {
            Debug.WriteLine(methodResult, "LogMethodOutputAttribute");
        }
    }


    public class Address2
    {
        public string Street { get; set; }
        public string City { get; set; }
    }
    public class User2
    {
        [AllowPrint(true)]
        public string Name { get; set; }
        [AllowPrint(false)]
        public int Age { get; set; }
        //Error - Func niestety nie jest dozwolony w atrybucie
        //[ConvertToString(new Func<object, string>(x=>""))]
        [AllowPrint(false)]
        public Address2 Address { get; set; } = new Address2();
        [LogMethodOutput()]
        public string GetFullAddress(string postCode = "00-000")
        {
            return $"{Address.Street} {postCode} {Address.City}";
        }
    }
    public class ReflectionAttributeSample
    {
        public static void ReflectionAttributeSampleTest()
        {
            var userProperties = typeof(User2).GetProperties();
            foreach (var userProperty in userProperties)
            {
                var allowPrintAttribute = (AllowPrintAttribute)userProperty.GetCustomAttributes(typeof(AllowPrintAttribute), true).FirstOrDefault();
                if (allowPrintAttribute != null && allowPrintAttribute.IsAllowPrint)
                {
                    Debug.WriteLine($"{userProperty.PropertyType.FullName} {userProperty.Name}", "print properties");
                }
            }

            var user = new User2()
            {
                Name = "Andrzej",
                Age = 50,
                Address = new Address2() { City = "Warszawa", Street = "Marszałkowska" }
            };

            var getFullAddressMethod = typeof(User2).GetMethod("GetFullAddress");
            RunMethodWithLogMethodOutputWrapper(getFullAddressMethod, user, new object[] { (object)"01-100" });
        }

        private static object RunMethodWithLogMethodOutputWrapper(MethodInfo methodInfo, object targetObj, object[] parameters)
        {
            var result = methodInfo.Invoke(targetObj, parameters);
            var logMethodOutputAttribute = (LogMethodOutputAttribute)methodInfo.GetCustomAttribute<LogMethodOutputAttribute>();
            if (logMethodOutputAttribute != null)
            {
                logMethodOutputAttribute.Log(result);
            }
            return result;
        }

    }
}
