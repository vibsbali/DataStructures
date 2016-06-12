using System;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var myDequeue = new QueueArray<int>();

            for (int i = 0; i < 4; i++)
            {
                myDequeue.Enqueue(i);
            }

            Console.WriteLine(myDequeue.Deque());

            for (int i = 4; i < 9; i++)
            {
                myDequeue.Enqueue(i);
            }

            for (int i = 9; i < 16; i++)
            {
                myDequeue.Enqueue(i);
            }
        }
    }
}
