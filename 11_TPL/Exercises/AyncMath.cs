using System;
using System.Collections.Generic;
using System.Text;

namespace _11_TPL.Exercises
{
    //Stworzyć klasę obsługującą asynchroniczne operacje Sum(+), Sub(-), Mult(*), Div(/)
    //Każda operacja powinna być opóźniona o 5 sekund
    //Wynik każdej operacji zapisywać do konsoli i zwracać
    //Przetestować za pomocą Task.ContinueWith() oraz await:
    //(15-5)*(3+5) / (2+2) = 20
    //Div(Mul(Sub(15,5),Sum(3,5)),Sum(2,2))
    //Sub(15,5) i Sum(3,5) oraz Mul(Sub(15,5),Sum(3,5)) i Sum(2,2) powinny się wykonywac równolegle
    //Zmierzyć czas wykonania za pomocą Stopwatch - powinien oscylować ~15s
    public class AyncMath
    {
    }
}
