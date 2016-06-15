using System;
using System.Collections.Generic;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var myArray = new[] {1, 9, 4, 8, 5, 3, 9, 0};
            
            var insertionSort = new InsertionSort<int>();
            insertionSort.Sort(myArray);

            foreach (var i in myArray)
            {
                Console.WriteLine(i);
            }

        }
    }
}
