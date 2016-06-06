using System;

namespace SortingAlgorithms
{
    public class SelectionSort
    {
        public void Sort<T>(T[] items) where T: IComparable<T>
        {

            for (int i = 0; i < items.Length; i++)
            {
                int minIndex = FindMinimumIndex(i, items);
                
                ShiftArray(i, minIndex, items);
            }
        }


        public int FindMinimumIndex<T>(int startIndex, T[] arrayToSearch) where T: IComparable<T>
        {
            var min = arrayToSearch[startIndex];
            var minIndex = startIndex;
            for (int i = startIndex; i < arrayToSearch.Length - 1; i++)
            {
                if (min.CompareTo(arrayToSearch[i+1]) > 0)
                {
                    min = arrayToSearch[i + 1];
                    minIndex = i + 1;
                }
            }

            return minIndex;
        }

        public void ShiftArray<T>(int startIndex, int minPosIndex, T[] items)
        {
            var temp = items[minPosIndex];

            for (int i = minPosIndex; i > startIndex; i--)
            {
                items[i] = items[i - 1];
            }

            items[startIndex] = temp;
        }
    }
}
