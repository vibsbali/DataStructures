using System;
using ConcreteStructures;
using Core;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new CircularLinkedList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(list.Contains(4));
            Console.WriteLine(list.Contains(42));

            list.Remove(5);
            list.Remove(1);
            list.Remove(3);
            list.Remove(42);
            list.Remove(4);

            list.Add(5);
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }

        static void Print(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node);
                node = node.Next;
            } 
        }
    }
}
