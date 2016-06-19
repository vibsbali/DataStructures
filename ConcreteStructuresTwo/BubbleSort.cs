using System;

namespace DataStructures
{
    public class BubbleSort<T>
            where T : IComparable<T>
    {
        private bool swapPerformed;

        public void Sort(T[] arrayToSort)
        {
            do
            {
                swapPerformed = false;
                for (int i = 0; i < arrayToSort.Length - 1; i++)
                {
                    //If LHS > RHS shift array
                    if (arrayToSort[i].CompareTo(arrayToSort[i + 1]) == 1)
                    {
                        swapPerformed = true;
                        Swap(i, i + 1, arrayToSort);
                    }
                }
            } while (swapPerformed);
        }



        private void Swap<T>(int fromPosition, int toPosition, T[] arrayToSwap)
        {
            if (fromPosition != toPosition)
            {
                var temp = arrayToSwap[toPosition];
                arrayToSwap[toPosition] = arrayToSwap[fromPosition];
                arrayToSwap[fromPosition] = temp;
            }
        }
    }
}
