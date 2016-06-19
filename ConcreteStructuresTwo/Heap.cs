using System;

namespace DataStructures
{
    public class Heap<T> where T: IComparable<T>
    {
        private T[] backingArray;
        public int Count { get; private set; }

        public readonly int DefaultLength;

        public Heap() : this(1)
        {
        }

        public Heap(int length)
        {
            DefaultLength = length;
            backingArray = new T[DefaultLength];
            Count = 0;
        }

        public void Add(T value)
        {
            //Check if ample room to add into existing array
            if (Count >= backingArray.Length)
            {
                GrowArray();
            }

            //Start pushing items to the end of the array 
            backingArray[Count] = value;
            RebalanceTree(Count);

            Count++;
        }

        private void RebalanceTree(int index)
        {
            var parentIndex = ParentIndex(index);
            if (backingArray[index].CompareTo(backingArray[parentIndex]) > 0 && index != 0)
            {
                Swap(index,parentIndex);  
                RebalanceTree(parentIndex);      
            }
        }

        private void GrowArray()
        {
            var newLength = Count * 2;
            var tempArray = new T[newLength];

            Array.Copy(backingArray, 0, tempArray, 0, Count);
            backingArray = tempArray;
        }

        public T Peek()
        {
            if (Count > 0)
            {
                return backingArray[0];
            }

            throw new InvalidOperationException("Can't call peek on Empty Queue");
        }

        public T RemoveMax()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            var maxValue = backingArray[0];

            //Replace the last value with head 
            backingArray[0] = backingArray[Count - 1];
            Count--;

            //Now rebalance the tree again
            int currentParentIndex = 0;

            //We Start with index 0 i.e. root and go down
            while (currentParentIndex < Count)
            {
                //Get the left and right child indexes
                int left = (2*currentParentIndex) + 1;
                int right = (2*currentParentIndex) + 2;

                //Make sure we are still within the heap
                if (left >= Count)
                {
                    break;
                }

                //Get the maximum child (index) between left and right child
                int maxChildIndex = IndexOfMaxChild(left, right);

                //Compare it with current parent of right and left nodes to check if current is bigger or less then
                //children
                if (backingArray[currentParentIndex].CompareTo(backingArray[maxChildIndex]) > 0)
                {
                    //The current item is larger than its children (heap property is satisfied)
                    break;
                }

                Swap(currentParentIndex, maxChildIndex);
                currentParentIndex = maxChildIndex;
            }

            return maxValue;
        }

        private int IndexOfMaxChild(int left, int right)
        {
            //Find the index of the child with the largest value
            int maxchildValue = -1;
            if (right >= Count)
            {
                //No right child/
                maxchildValue = left;
            }
            else
            {
                if (backingArray[left].CompareTo(backingArray[right]) > 0)
                {
                    maxchildValue = left;
                }
                else
                {
                    maxchildValue = right;
                }
            }

            return maxchildValue;
        }

        public void Clear()
        {
            backingArray = new T[DefaultLength];
            Count = 0;
        }

        private int ParentIndex(int index)
        {
            return (index - 1)/2;
        }

        private void Swap(int left, int right)
        {
            var temp = backingArray[left];
            backingArray[left] = backingArray[right];
            backingArray[right] = temp;
        }
    }
}
