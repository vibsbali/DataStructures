using System;
using System.Diagnostics.Eventing.Reader;

namespace ConcreteStructures
{
    public class DequeOfArray<T>
    {
        T[] backingArray = new T[0];

        private int size = 0;
        private int head = 0;
        private int tail = -1;

        private void AllocateNewArray(int startingIndex)
        {
            int newLength = size == 0 ? 4 : size * 2;
            var newArray = new T[newLength];

            if (size > 0)
            {
                int targetIndex = startingIndex;

                //Copy the contents..
                //if the array has no wrpping, just copy the valid range.
                //Else, copy from head to end of the array and then from 0 to the tail

                //This is the case where there is wrapping (tail is less than head)
                if (tail < head)
                {
                    for (int i = head; i < backingArray.Length; i++)
                    {
                        newArray[targetIndex] = backingArray[i];
                        targetIndex++;
                    }

                    //Copy remaining items upto tail pointer
                    for (int i = 0; i <= tail; i++)
                    {
                        newArray[targetIndex] = backingArray[i];
                        targetIndex++;
                    }
                }
                else
                {
                    for (int i = 0; i < backingArray.Length; i++)
                    {
                        newArray[targetIndex] = backingArray[i];
                        targetIndex++;
                    }
                }

                head = startingIndex;
                tail = targetIndex - 1;
            }
            else
            {
                //nothing in the array
                head = 0;
                tail = -1;
            }

            backingArray = newArray;
        }

        public void EnqueueFirst(T item)
        {
            if (backingArray.Length == size)
            {
                AllocateNewArray(1);
            }
        }

        public void EnqueueLast(T item)
        {
           
        }

        public T DequeueFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

           
        }

        public T DequeueLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

           
        }

        public T PeekFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }
           
        }

        public T PeekLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }
           
        }

        public int Count
        {
            get
            {
                return;
            }
        }
    }
}
