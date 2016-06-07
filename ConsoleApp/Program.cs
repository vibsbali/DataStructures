using System;
using CoreNew;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var nodeOne = new Node<int>(1);
            
            var nodeTwo = new Node<int>(2);
            

            var nodeThree = new Node<int>(3);
            

            var list = new LinkedList<int>();
            list.AddToFront(nodeOne);
            list.AddToBack(nodeTwo);
            list.AddToBack(nodeThree);

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            
        }

        static void Print<T>(T[] stack)
        {
            for (int i = 0; i < stack.Length; i++)
            {
                Console.WriteLine(stack[i]);
            }
        }
    }
}
