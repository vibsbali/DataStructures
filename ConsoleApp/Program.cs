using System;
using SortingAlgorithms;

namespace ConsoleApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            var items = new[] {1, 3, 23, 5, 5, 7, 10};

            var bubbleSort = new BubbleSort();
            bubbleSort.Sort(items);

            Print(items);
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
