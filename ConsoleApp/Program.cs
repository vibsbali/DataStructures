using System;
using CoreNew;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var nodeOne = new Node<int>(1);
            
            var nodeTwo = new Node<int>(2);
            nodeOne.Next = nodeTwo;

            var nodeThree = new Node<int>(3);
            nodeTwo.Next = nodeThree;

            var nodeToPrint = nodeOne;
            while (nodeToPrint != null)
            {
                Console.WriteLine(nodeToPrint.Value);
                nodeToPrint = nodeToPrint.Next;
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
