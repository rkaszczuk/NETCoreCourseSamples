using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _09_Reflection.Samples
{
    public class Address3
    {
        public string Street { get; set; }
        public string City { get; set; }
    }
    public class User3
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address3 Address { get; set; } = new Address3();
        public string GetFullAddress(string postCode = "00-000")
        {
            return $"{Address.Street} {postCode} {Address.City}";
        }
    }

    public class ReflectionObjectConstructionSample<T> where T: new()
    {
        private T instance;
        public void CreateNewinstance()
        {
            instance = Activator.CreateInstance<T>();
            instance = (T)Activator.CreateInstance(typeof(T));
        }
        public void SetPropertyValue<TP>(string propertyName, TP value)
        {
            var property = instance.GetType().GetProperty(propertyName);
            if (property == null)
            {
                Debug.WriteLine("Property not found");
            }
            else if(property.PropertyType != typeof(TP))
            {
                Debug.WriteLine("Property type is not the same as passing type");
            }
            else
            {
                property.SetValue(instance, value);
            }
        }

        public TP GetPropertyValue<TP>(string propertyName)
        {
            var property = instance.GetType().GetProperty(propertyName);
            if (property == null)
            {
                Debug.WriteLine("Property not found");
                return default(TP);
            }
            else if (property.PropertyType != typeof(TP))
            {
                Debug.WriteLine("Property type is not the same as passing type");
                return default(TP);
            }
            return (TP)property.GetValue(propertyName);           
        }
    }


}
