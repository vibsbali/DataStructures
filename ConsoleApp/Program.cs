using System;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var myDequeue = new DequeueArray<int>();

            myDequeue.EnqueueFirst(10);
            myDequeue.EnqueueFirst(20);
            myDequeue.EnqueueFirst(10);
            myDequeue.EnqueueFirst(20);
            myDequeue.EnqueueFirst(10);
            myDequeue.EnqueueFirst(20);
            myDequeue.EnqueueFirst(10);
            myDequeue.EnqueueFirst(20);

            Console.WriteLine(myDequeue.DequeFirst());
            Console.WriteLine(myDequeue.DequeLast());

        }
    }
}
