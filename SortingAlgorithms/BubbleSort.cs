using System;

namespace SortingAlgorithms
{
    //Bubble sort is a naive sorting algorithm that operates by making multiple passes through the array,
    //each time moving the largest unsorted value to the end of the array Time complexity O(n^2) and space complexit O(1)
    public class BubbleSort
    {
        public void Sort<T>(T[] items) where T : IComparable<T>
        {
            bool swapped;

            do
            {
                swapped = false;
                for (int i = 1; i < items.Length; i++)
                {
                    if (items[i - 1].CompareTo(items[i]) > 0)
                    {
                        items.Swap(i -1, i);
                        swapped = true;
                    }
                }
            } while (!swapped);
        }
    }
}
