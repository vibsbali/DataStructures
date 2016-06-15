using System;

namespace DataStructures
{
    public class MergeSort<T>
        where T : IComparable<T>
    {
        public void Sort(int[] myArray)
        {
            if (myArray.Length == 1)
            {
                return;
            }

            var leftArrayLength = myArray.Length / 2;
            var rightArrayLength = myArray.Length - leftArrayLength;

            var newLeftArray = new int[leftArrayLength];
            var newRightArray = new int[rightArrayLength];

            Array.Copy(myArray, 0, newLeftArray, 0, leftArrayLength);
            Array.Copy(myArray, leftArrayLength, newRightArray, 0, rightArrayLength);

            Sort(newLeftArray);
            Sort(newRightArray);
            Merge(myArray, newLeftArray, newRightArray);
        }

        private static void Merge(int[] items, int[] left, int[] right)
        {
            var remaining = left.Length + right.Length;

            var index = 0;
            var rightIndex = 0;
            var leftIndex = 0;
            while (remaining > 0 && rightIndex < right.Length && leftIndex < left.Length)
            {
                if (left[leftIndex] > right[rightIndex])
                {
                    items[index] = right[rightIndex];
                    rightIndex++;
                }
                else
                {
                    items[index] = left[leftIndex];
                    leftIndex++;
                }
                remaining--;
                index++;
            }

            while (left.Length > leftIndex)
            {
                items[index] = left[leftIndex];
                index++;
                leftIndex++;
            }

            while (right.Length > rightIndex)
            {
                items[index] = right[rightIndex];
                index++;
                rightIndex++;
            }
        }
    }
}
