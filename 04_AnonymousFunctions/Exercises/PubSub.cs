using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _04_AnonymousFunctions.Exercises
{
    //Wzorzec Publish-Subscribe opera się na mechaniżmie subskrypcji na dane wydarzenie.
    //Subskrypcja odbywa się w elemencie publikującym
    //W momencie zaistnienia danego zdarzenia element publikujący powiadamia wszystkich zapisanych subskrybentów (np. za pomoca wykonania danej metody)

    //Należy stworzyć prosty mechanizm Publish-Subscribe
    //Publisher powinien pozwalać na zapisywanie dowolnej akcji subskrybenta, przyjmującej jako parametr temat wiadomości (string)
    //W momencie zapisywania subskrybent wskazuje interesujący go temat (string)
    //W momencie wykonania akcji Notify z przekazanym tematem powinno nastąpić wyszukanie wszystkich powiązanych z tym tematem subskrypcji oraz ich uruchomienie
    public class Publisher
    {
        public void Notify(string topicName)
        {
            throw new NotImplementedException();
        }
    }

    public class Subscriber1
    {
        public void OnSubscribe(string topicName)
        {
            Debug.WriteLine(topicName);
        }
    }
    public class Subscriber2
    {
        public void OnSubscribeToUpper(string topicName)
        {
            Debug.WriteLine(topicName.ToUpper());
        }
    }
    public class Subscriber3
    {
        public void OnSubscribeRevers(string topicName)
        {
            char[] charArray = topicName.ToCharArray();
            Array.Reverse(charArray);
            Debug.WriteLine(new string(charArray));
        }
    }
}
