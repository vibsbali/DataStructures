using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Remoting.Messaging;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var heap = new Heap<int>();

            heap.Add(8);
            heap.Add(6);
            heap.Add(5);
            heap.Add(3);
            heap.Add(4);
            heap.Add(10);
            heap.Add(9);
            heap.Add(10);

            heap.RemoveMax();

        }
    }
}
