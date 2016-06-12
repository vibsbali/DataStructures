using System;

namespace DataStructures
{
    public class DequeueArray<T>
    {
        private T[] backingArray;
        private static int defaultSize = 2;

        private int Head { get; set; }
        private int Tail { get; set; }

        public int Count { get; private set; }

        public DequeueArray():this(defaultSize)
        {
        }

        public DequeueArray(int size)
        {
            backingArray = new T[size];
        }

        public void EnqueueFirst(T value)
        {
            //Ensure enough space is available
            if (backingArray.Length == Count)
            {
                GrowArray();
            }

            //Check whether Head is greater than 0 i.e. Head is a the end of Array - Wrapped!
            if (Head > 0)
            {
                Head--;
            }
            else
            {
                //otherwise we need to wrap around to the end of the array
                Head = backingArray.Length - 1;
            }

            backingArray[Head] = value;

            Count++;
        }


        private void GrowArray()
        {
            T[] newArray = new T[backingArray.Length * 2];
            //Are we wrapped
            if (Tail < Head)
            {
                var numberOfItemsFromHeadToEndOfArray = backingArray.Length - Head;
                var numberOfItemsFromStartingToTail = backingArray.Length - numberOfItemsFromHeadToEndOfArray;
                Array.Copy(backingArray, Head, newArray, 0, numberOfItemsFromHeadToEndOfArray);
                Array.Copy(backingArray, 0, newArray, numberOfItemsFromHeadToEndOfArray,
                    numberOfItemsFromStartingToTail - 1);
            }
            else
            {
                Array.Copy(backingArray, 0, newArray, 0, backingArray.Length - 1);
            }

            Head = 0;
            Tail = Count - 1;

            backingArray = newArray;
        }

        public void EnqueueLast(T value)
        {
            //check if any space left
            if (backingArray.Length == Count)
            {
                GrowArray();
            }

            //Set Tail
            //if we did not increase the size of the array it means one slot is empty
            //Check if Tail is the end of the array i.e. last item in the array
            if (Tail == backingArray.Length - 1)
            {
                Tail = 0;
            }
            else
            {
                Tail++;
            }

            backingArray[Tail] = value;
            
            //Increase count
            Count++;
        }

        public T DequeFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot call deque on empty queue");
            }

            //Find head
            var indexToReturn = Head;
            if (Head == backingArray.Length - 1)
            {
                Head = 0;
            }
            else
            {
                Head++;
            }

            Count--;

            return backingArray[indexToReturn];
        }

        public T DequeLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot call deque on empty queue");
            }

            //Find Tail
            var indexToReturn = Tail;

            //Wrap it around
            if (Tail == 0)
            {
                Tail = backingArray.Length - 1;
            }
            else
            {
                Tail--;
            }

            Count--;
            return backingArray[indexToReturn];
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot call deque on empty queue");
            }

            return backingArray[Head];
        }
    }

 
}
