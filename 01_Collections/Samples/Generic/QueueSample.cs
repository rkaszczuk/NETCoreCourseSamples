using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace _01_Collections.Samples.Generic
{
    public class QueueSample
    {
        public static void QueueTest()
        {
            Queue<string> queue = new Queue<string>();

            //Dodanie elementów do kolejki
            queue.Enqueue("User1");
            queue.Enqueue("User2");
            queue.Enqueue("User3");

            queue.PrintCollection("queue");
            
            //Pobranie i usunięcie pierwszego elemetu w kolejce
            var result = queue.Dequeue();
            Debug.WriteLine(result, "Dequeue - result");

            queue.PrintCollection("queue after dequeue");

            //Pobranie pierwszego elemetu w kolejce bez usuwania
            result = queue.Peek();

            Debug.WriteLine(result, "Peek - result");

            queue.PrintCollection("queue after peek");

            //W przypadku braku elementów w kolejce Dequeue() zwróci exception
            try
            {
                queue.Dequeue();
                queue.Dequeue();
                queue.Dequeue();
                queue.Dequeue();
                queue.Dequeue();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex, "Queue empty exception");
            }

            queue.Enqueue("User1");
            //Bezpieczne pobieranie elementów z kolejki
            string result2;
            queue.TryPeek(out result2);
            Debug.WriteLine(result2 ?? null, "TryPeek");
            queue.TryDequeue(out result2);
            Debug.WriteLine(result2 ?? null, "TryDequeue");
            queue.TryDequeue(out result2);
            Debug.WriteLine(result2 ?? null, "TryDequeue");
            queue.TryPeek(out result2);
            Debug.WriteLine(result2 ?? null, "TryPeek");
        }
    }
}
