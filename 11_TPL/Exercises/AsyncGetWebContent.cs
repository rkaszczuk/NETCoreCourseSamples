using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace _11_TPL.Exercises
{
    //Na podstawie metody GetPage stworzyć jej asynchroniczną wersję GetPageAsync
    //Wypróbowac równoczesne wykonanie 3 tasków GetPageAsync(5)
    //Zmierzyć czas wykonania 3 tasków - powinien oscylować ~5 sekund
    //Stworzyć metodę async GetPageAsyncBuiltIn z wykorzystaniem WebClient.DownloadStringAsync
    //Zmierzyć czas wykonania 3 równoecznych wykonań GetPageAsyncBuiltIn - powinien oscylować ~5 sekund
    public class AsyncGetWebContent
    {
        public string GetPage(int delaySecond)
        {
            var url = $"https://httpbin.org/delay/{delaySecond}";
            var webClient = new WebClient();
            return webClient.DownloadString(url);
        }

    }
}
