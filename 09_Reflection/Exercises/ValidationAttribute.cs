using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _09_Reflection.Exercises
{
    public class LayerResult<T>
    {
        public T Result { get; set; }
        public List<string> Errors { get; set; }
        public bool IsSuccess { get => !Errors.Any(); }
    }



    public interface IValidationAttribute
    {
        void Validate(Type objectType, object obj, string memberName);
    }

    //MaxStringLengthAttribute(int maxLength)
    //Sprawdza maksaymalną długośc string, 
    //jeżeli properta nie jest typu string lub jest dłuża od maxLength - zwraca exception

    //+Metoda sprawdzająca obiekt za pomocą refleksji


    public class MaxStringLengthAttribute : Attribute, IValidationAttribute
    {
        private int maxLength;
        public MaxStringLengthAttribute(int maxLength)
        {
            this.maxLength = maxLength;
        }
        public void Validate(Type objectType, object obj, string memberName)
        {
            if(objectType != typeof(string))
            {
                throw new Exception("MaxStringLengthAttribute może być użyty tylko na typ string");
            }
            var stringValue = (string)obj;
            if(stringValue.Length > maxLength)
            {
                throw new Exception($"Długość napisu nie może być dłuższa niż {maxLength}");
            }
        }
    }

    public class NotNullAttribute : Attribute, IValidationAttribute
    {
        public void Validate(Type objectType, object obj, string memberName)
        {
            if (obj == null)
            {
                throw new Exception($"Wartość {memberName} nie może być nullem!");
            }
        }
    }

    public class NotEqualAttribute : Attribute, IValidationAttribute
    {
        private object notEqualValue;
        public NotEqualAttribute(object notEqualValue)
        {
            this.notEqualValue = notEqualValue;
        }
        public void Validate(Type objectType, object obj, string memberName)
        {
            if (obj.Equals(notEqualValue))
            {
                throw new Exception($"Wartość {memberName} nie może być równa {notEqualValue}");
            }
        }
    }

    public class ValidationAttribute
    {
        public void ValidateObject<T>(T obj)
        {
            var properties = obj.GetType().GetProperties();
            foreach(var property in properties)
            {
                var validatorAttributes = property.GetCustomAttributes(true)
                    .Where(x => x.GetType().GetInterface("IValidationAttribute") != null);

                var propertyValue = property.GetValue(obj);
                foreach (var validator in validatorAttributes)
                {
                    ((IValidationAttribute)validator).Validate(property.PropertyType, propertyValue, property.Name);
                }
                
            }
        }

    }
}
