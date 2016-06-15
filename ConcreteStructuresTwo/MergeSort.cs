#region Algorithm Explanation
/*Algorithm
http://www.tutorialspoint.com/data_structures_algorithms/merge_sort_algorithm.htm
Merge sort keeps on dividing the list into equal halves until it can no more be divided. 
By definition, if it is only one element in the list, it is sorted. Then merge sort combines smaller sorted lists keeping the new list sorted too.

Step 1 − if it is only one element in the list it is already sorted, return.
Step 2 − divide the list recursively into two halves until it can no more be divided.
Step 3 − merge the smaller lists into new list in sorted order.

    Pseudocode
We shall now see the pseudocodes for merge-sort functions. As our algorithms points out two main functions − divide & merge.

Merge sort works with recursion and we shall see our implementation in the same way

procedure mergesort( var a as array )
   if ( n == 1 ) return a

   var l1 as array = a[0] ... a[n/2]
   var l2 as array = a[n/2+1] ... a[n]

   l1 = mergesort( l1 )
   l2 = mergesort( l2 )

   return merge( l1, l2 )
end procedure

procedure merge( var a as array, var b as array )

   var c as array

   while ( a and b have elements )
      if ( a[0] > b[0] )
         add b[0] to the end of c
         remove b[0] from b
      else
         add a[0] to the end of c
         remove a[0] from a
      end if
   end while
   
   while ( a has elements )
      add a[0] to the end of c
      remove a[0] from a
   end while
   
   while ( b has elements )
      add b[0] to the end of c
      remove b[0] from b
   end while
   
   return c
	
end procedure
*/

#endregion

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


