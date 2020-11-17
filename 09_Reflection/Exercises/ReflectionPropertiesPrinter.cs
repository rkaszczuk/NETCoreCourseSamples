using _09_Reflection.Samples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace _09_Reflection.Exercises
{
    //Stworzyć metodę statyczną wypisującą informację o właściwościach:
    //Typ, Nazwa, Wartość
    //Wykonać na jakimś obiekcie (może być samodzielnie zadeklarowany)
    /*
            Type userType = typeof(User);
            userType = user.GetType();

            foreach(var property in userType.GetProperties())
    */
    //Dodać atrybut [NoPrint], który sprawi że properta nie będzie wypisywana w metodzie 
    //PrintObjectProperties

    

    public class ReflectionPropertiesPrinter
    {
        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
        public static void  PrintObjectProperties(Type type, Object obj, string prefix)
        {
            Debug.WriteLine(type.Name, prefix);
            foreach(var property in type.GetProperties())
            {
                var propertyValue = property.GetValue(obj);
                if(propertyValue.Equals(GetDefault(property.PropertyType)))
                {
                    var defaultValueAttribute =
                        property.GetCustomAttributes(typeof(DefaultValueAttribute), true);
                    if (defaultValueAttribute.Any())
                    {
                        propertyValue = ((DefaultValueAttribute)defaultValueAttribute[0]).DefaultValue;
                    }
                }

                var noPrintAttribute = property.GetCustomAttributes(typeof(NoPrintAttribute), true);
                if (noPrintAttribute.Any())
                {
                    continue;
                }

                if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string))
                {                   
                    Debug.WriteLine($"{property.PropertyType} {property.Name} {propertyValue}", prefix);
                }
                else
                {
                    PrintObjectProperties(property.PropertyType, propertyValue, prefix + "->"+ property.Name);
                }
            }
        }
    }
}
