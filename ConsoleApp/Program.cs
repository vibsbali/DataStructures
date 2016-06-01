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

            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(34);

            
            list.Remove(5);
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
