using System;

namespace DataStructures
{
    public class InsertionSort<T>
        where T : IComparable<T>
    {
        // ReSharper disable once InconsistentNaming
        public void Sort(T[] A)
        {
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i].CompareTo(A[i - 1]) == -1)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (A[j].CompareTo(A[i]) == 1)
                        {
                            Shift(i, j, A);
                            break;
                        }
                    }
                }
            }
        }

        private void Shift<T>(int fromIndex, int toIndex, T[] arrayToSwap)
        {
            var temp = arrayToSwap[fromIndex];
            for (int i = fromIndex; i > toIndex; i--)
            {
                arrayToSwap[i] = arrayToSwap[i - 1];
            }
            arrayToSwap[toIndex] = temp;
        }
    }
}
