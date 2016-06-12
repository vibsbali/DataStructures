using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class QueueArray<T> 
    {
        private T[] backingArray;
        private const int DefaultSize = 16;
        public int Count { get; private set; }

        private int head = 0;
        private int tail = -1;

        public QueueArray() : this(DefaultSize)
        {

        }

        public QueueArray(int size)
        {
            backingArray = new T[size];
        }


        private void GrowArray()
        {
            var temp = new T[backingArray.Length * 2];
            Array.Copy(temp, 0, backingArray, 0, backingArray.Length - 1);
            backingArray = temp;
        }

        public void Enqueue(T item)
        {
            if (backingArray.Length == Count)
            {
                GrowArray();
            }

            backingArray[Count] = item;
            ++Count;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot call Pop on empty stack");
            }

            var itemToReturn = backingArray[Count - 1];
            Count--;
            return itemToReturn;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot call Peek on empty stack");
            }

            return backingArray[Count - 1];
        }
    }
}
