using System;
using System.Collections.Generic;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var myArray = new[] {1, 2, 3, 4, 5, 6, 7};
            
            var bubbleSort = new BubbleSort<int>();
            bubbleSort.Sort(myArray);

            foreach (var i in myArray)
            {
                Console.WriteLine(i);
            }

        }
    }
}
