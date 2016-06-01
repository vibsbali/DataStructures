using System;
using ConcreteStructures;
using Core;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Quit to exit");
            var input = "";
            var circularQueue = new CircularLinkedList<int>();

            while (input.ToLower() != "quit")
            {
                input = Console.ReadLine();
                circularQueue.Add(int.Parse(input));

                foreach (var i in circularQueue)
                {
                    Console.Write(i);
                }
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
