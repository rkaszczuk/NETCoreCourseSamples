using System;
using System.Collections.Generic;
using System.Text;

namespace _10_Multithreading.Exercises
{
    //Wzorzec projektowy "Pula obiektów" jest wzorcem kreacyjnym pozwalającym na reużywanie obiektów
    //Jest szczególnie przydatny w przypadku dużych obiektów (w celu oszczędzania pamięci) 
    //lub używających I/O (np. w celu uniknięcia nawiązywania wielu połączeń sieciowych)
    //Jego istotą jest stworzenie kolekcji obiektów, które są "wypożyczane" z puli, a po zakończeniu ich wykorzystywania zwracane spowrotem

    //Nalezy stworzyć implementację prostego ObjectPool i przetestować go za pomocą ObjectPoolSampleObj
    //Powinna być możliwośc "wypożyczania" i "zwracania" obiektów oraz określania rozmiaru póli
    //Object pool powinien działać w środowisku wielowątkowym
    //Jeżeli nie ma obiektów do "wypożyczenia" - wątek powinien oczekiwać
    //Informację o zwróceniu obiektu można wykonać za pomoca ResetEventów (zamiast while) lub użyć semafora

    public class ObjectPool<T>
    {
    }

    public class ObjectPoolSampleObj
    {
        public void DoSomeJob()
        {
            System.Threading.Thread.Sleep(1000);
        }
    }
}
