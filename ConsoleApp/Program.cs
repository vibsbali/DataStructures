using System;
using CoreNew;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var list = new DoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }


            list.RemoveFromBack();
            list.RemoveFromFront();

            var current = list.Head;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
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
