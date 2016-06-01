using System;
using ConcreteStructures;
using Core;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNode = new Node {Value = 3 };

            var middleNode = new Node { Value = 5 };
            

            var lastNode = new Node { Value = 7 };

            var list = new DoublyLinkedList<int>();

            list.AddFirst(3);
            list.AddFirst(4);

            Console.WriteLine(list.Contains(5));
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
