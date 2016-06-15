using System;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var myArray = new[] {3, 8, 2, 1, 5, 5, 4, 6, 7};

            var mergeSort = new MergeSort<int>();
            mergeSort.Sort(myArray);

            foreach (var i in myArray)
            {
                Console.WriteLine(i);
            }

        }

        
    }
}
