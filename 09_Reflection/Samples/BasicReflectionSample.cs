using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using _09_Reflection.Exercises;

namespace _09_Reflection.Samples
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultValueAttribute : Attribute
    {
        public object DefaultValue { get; set; }
        public DefaultValueAttribute(object defaultValue)
        {
            DefaultValue = defaultValue;
        }
    }

    public class NoPrintAttribute : Attribute
    {
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    public class User
    {
        [MaxStringLength(5)]
        public string Name { get; set; }
        [DefaultValue(18)]
        public int Age { get; set; }
        [NoPrintAttribute]
        public Address Address { get; set; } = new Address();
        public string GetFullAddress(string postCode = "00-000")
        {
            return $"{Address.Street} {postCode} {Address.City}";
        }
    }
    public class BasicReflectionSample
    {
        public static void BasicReflectionSampleTest()
        {
            //Wypisywanie wszystkich propertis wraz z ich typami
            var userProperties = typeof(User).GetProperties();
            foreach(var userProperty in userProperties)
            {
                Debug.WriteLine($"{userProperty.PropertyType.FullName} {userProperty.Name}", "print properties");
            }

            //We need to go deeper :)
            //Wypisywanie równeż zagnieżdżonych propert
            void PrintProperties(Type type)
            {
                var properties = type.GetProperties();
                foreach(var property in properties)
                {
                    if (property.PropertyType.IsValueType || property.PropertyType== typeof(string))
                    {
                        Debug.WriteLine($"{property.PropertyType.FullName} {property.Name}", "print all properties (ValueType)");
                    }
                    else if(property.PropertyType.IsClass)
                    {
                        PrintProperties(property.PropertyType);
                    }
                    else
                    {
                        Debug.WriteLine($"{property.PropertyType.FullName} {property.Name}", "print all properties (other)");
                    }
                }
            }

            PrintProperties(typeof(User));

            //Spróbujmy pobrać wartości
            void PrintPropertiesWithValues<T>(T obj)
            {
                var properties = obj.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var propertyValue = property.GetValue(obj);
                    if (property.PropertyType.IsValueType || property.PropertyType == typeof(string))
                    {
                        Debug.WriteLine($"{property.PropertyType.FullName} {property.Name} {propertyValue}", "print all properties with values (ValueType)");
                    }
                    else if (property.PropertyType.IsClass)
                    {
                        PrintPropertiesWithValues(propertyValue);
                    }
                    else
                    {
                        Debug.WriteLine($"{property.PropertyType.FullName} {property.Name}", "print all properties with values (other)");
                    }
                }
            }

            var user = new User()
            {
                Name = "Andrzej",
                Age = 50,
                Address = new Address() { City = "Warszawa", Street = "Marszałkowska" }
            };

            PrintPropertiesWithValues(user);

            //A teraz wypiszmy metody
            var userMethods = typeof(User).GetMethods();
            foreach(var userMethod in userMethods)
            {
                Debug.Write($"{userMethod.ReturnType} {userMethod.Name}", "userMethods");
                foreach(var parameters in userMethod.GetParameters())
                {
                    Debug.Write(" ");
                    Debug.Write($"{parameters.ParameterType} {parameters.Name} Default value: {parameters.DefaultValue}", "userMethods parameters");
                }
                Debug.WriteLine("");
            }

            //A bez getterów i setterów?
            var userMethods2 = typeof(User).GetMethods().Where(x=>!x.IsSpecialName);
            foreach (var userMethod in userMethods2)
            {
                Debug.Write($"{userMethod.ReturnType} {userMethod.Name}", "userMethods without setter/getter");
                foreach (var parameters in userMethod.GetParameters())
                {
                    Debug.Write(" ");
                    Debug.Write($"{parameters.ParameterType} {parameters.Name} Default value: {parameters.DefaultValue}", "userMethods parameters");
                }
                Debug.WriteLine("");
            }

            //A bez dziedziczenia z object?
            var userMethods3 = typeof(User).GetMethods().Where(x => !x.IsSpecialName && x.DeclaringType != typeof(object));
            foreach (var userMethod in userMethods3)
            {
                Debug.Write($"{userMethod.ReturnType} {userMethod.Name}", "userMethods without object");
                foreach (var parameters in userMethod.GetParameters())
                {
                    Debug.Write(" ");
                    Debug.Write($"{parameters.ParameterType} {parameters.Name} Default value: {parameters.DefaultValue}", "userMethods parameters");
                }
                Debug.WriteLine("");
            }

            //Spróbujmy wykonać metodę GetFullAddress
            var getFullAddressMethod = typeof(User).GetMethod("getfulladdress");
            if (getFullAddressMethod == null)
            {
                //Nazwa metody musi być zgodna co do wielkości znaków
                Debug.WriteLine("Method not found");
            }
            getFullAddressMethod = typeof(User).GetMethod("GetFullAddress");
            var result = getFullAddressMethod.Invoke(user, new object[] { (object)"01-100" });
            Debug.WriteLine(result, "getFullAddressMethod result");
        }
    }
}
