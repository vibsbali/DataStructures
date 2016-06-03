using System;
using System.Collections.Generic;

namespace ConcreteStructures
{
    public class Deque<T>
    {
        private readonly LinkedList<T> backingLinkedList; 
        public Deque()
        {
            backingLinkedList = new LinkedList<T>();
        }

        public void EnqueueFirst(T item)
        {
            backingLinkedList.AddFirst(item);
        }

        public void EnqueueLast(T item)
        {
            backingLinkedList.AddLast(item);
        }

        public T DequeueFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            var item = backingLinkedList.First;
            backingLinkedList.RemoveFirst();
            return item.Value;
        }

        public T DequeueLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            var item = backingLinkedList.Last;
            backingLinkedList.RemoveLast();
            return item.Value;
        }

        public T PeekFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }
            return backingLinkedList.First.Value;
        }

        public T PeekLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }
            return backingLinkedList.Last.Value;
        }

        public int Count
        {
            get
            {
                return backingLinkedList.Count;
            }
        }
    }
}
