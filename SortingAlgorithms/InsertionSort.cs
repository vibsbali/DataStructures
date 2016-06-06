using System;

namespace SortingAlgorithms
{
    public class InsertionSort
    {
        public void Sort<T>(T[] items)
            where T : IComparable<T>
        {
            var sortedRangeEndIndex = 1;

            while (sortedRangeEndIndex < items.Length)
            {
                if (items[sortedRangeEndIndex].CompareTo(items[sortedRangeEndIndex - 1]) < 0)
                {
                    int insertIndex = FindInsertionIndex(items, items[sortedRangeEndIndex]);
                    Insert(items, insertIndex, sortedRangeEndIndex);
                }

                sortedRangeEndIndex++;
            }
        }

        private void Insert<T>(T[] items, int insertIndex, int sortedRangeEndIndex) where T : IComparable<T>
        {
            //Step 1
            var temp = items[insertIndex];
            //Step 2
            items[insertIndex] = items[sortedRangeEndIndex];

            //Step 3 copy from back 
            for (int i = sortedRangeEndIndex; i > insertIndex; i--)
            {
                items[i] = items[i - 1];
            }

            //Step 4
            items[insertIndex + 1] = temp;
        }

        private int FindInsertionIndex<T>(T[] items, T valueToInsert) where T : IComparable<T>
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].CompareTo(valueToInsert) > 0)
                {
                    return i;
                }
            }

            throw new InvalidOperationException("The insertion index was not found");
        }
    }
}
