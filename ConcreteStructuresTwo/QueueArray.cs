using System;

//The Stack and Queue in .Net is based on Arrays so there should be no reason for you to implement this yourself.
//My methodology is working from back of the array towards zero index.

//Thought process
//1. Firstly I only though of how the datastructure would work without any wrapping 
//2. Then I implemented what would happen if I were to remove an item from the array and try to insert a new value
//3. I started with Enque method, followed by deque and lastly implemented growth algorithm
namespace DataStructures
{
    public class QueueArray<T> 
    {
        private T[] backingArray;
        private const int DefaultSize = 4;
        public int Count { get; private set; }

        private int Head { get; set; }
        private int Tail { get; set; }

        public QueueArray() : this(DefaultSize)
        {

        }

        public QueueArray(int size)
        {
            backingArray = new T[size];
            Head = backingArray.Length - 1;
            Tail = backingArray.Length;
        }


        private void GrowArray()
        {
            var temp = new T[backingArray.Length * 2];
            var headIndex = temp.Length - 1;
            //There could be two scenarios
            //TXXXXXXXH No Wrapping
            if (Tail < Head)
            {
                for (int i = Head; i >= Tail; i--)
                {
                    temp[headIndex] = backingArray[i];
                    headIndex--;
                }
                
            } //XXXHXXTXX With Wrapping
            else
            {
                for (int i = Head; i >= 0; i--)
                {
                    temp[headIndex] = backingArray[i];
                    headIndex--;
                }
                for (int i = backingArray.Length - 1; i >= Tail; i--)
                {
                    temp[headIndex] = backingArray[i];
                    headIndex--;
                }
            }

            Tail = backingArray.Length;    //Since we are doubling the array the Tail is length of the old array
            backingArray = temp;
            Head = backingArray.Length - 1;
        }

        public void Enqueue(T item)
        {
            if (backingArray.Length == Count)
            {
                GrowArray();
            }

            //This step will only occur if there are still any empty indexes to be filled 
            if (Tail == 0)
            {
                Tail = backingArray.Length;
            }

            Tail--;
            backingArray[Tail] = item;
            ++Count;
        }

        public T Deque()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot call Dequeue on empty Queue");
            }

            if (Head == -1)
            {
                Head = backingArray.Length - 1;
            }

            var itemToReturn = backingArray[Head];
            Head--;
            Count--;
            return itemToReturn;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot call Peek on empty Queue");
            }

            return backingArray[Head];
        }
    }
}
