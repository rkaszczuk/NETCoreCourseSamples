using System;
using System.Collections.Generic;
using System.Text;

namespace _10_Multithreading.Exercises
{
    //Należy stworzyć mechanizm zapisywania danych do pliku z wykorzystaniem pojedyńczego wątku
    //Wątek #1 tworzy plik i oczekuje na event o zapisie danych
    //Wątek #2 i wątek #3 w bezpieczny sposób dopisują wartości do zmiennej typu string
    //Po wygenerowaniu tekstu wysyłają event z prośbą o dopisanie danych do pliku
    //Po zapisie danych Wątek #1 czeka na informację czy ma zamknąć plik
    public class WriteToFileOnEvent
    {
    }
}
