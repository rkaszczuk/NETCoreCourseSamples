using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _03_AnonymousTypes.Samples
{
    public class BasicAnymousTypesSample
    {
        public static void BasicAnymousTypesSampleTest()
        {
            var user = new { Name = "Andrzej", Age = 40, Address = new { Street = "Marszałkowska", City = "Warszawa"}};
            Debug.WriteLine(user.Name, "user.Name");
            Debug.WriteLine(user.Address.City, "user.Address.City");

            //Error
            //Typy anonimowe są readonly
            //user.Name = "Zbigniew";

            //Error
            //Nie można przypisywać lambd bezpośrednio do typów anonimowych
            //var getFullAddress = new { GetFullAddress = ()=> $"{user.Address.City} {user.Address.Street}"};

            //Ale Func/Action już tak
            var getFullAddress = new { GetFullAddress = new Func<string>(()=> $"{user.Address.City} {user.Address.Street}")};
            Debug.WriteLine(getFullAddress.GetFullAddress(), "Type FullName");
        }
    }
}
