using System;
using System.Collections.Generic;

namespace ConcreteStructures
{
    public class DsQueue<T>
    {
        private readonly LinkedList<T> backingLinkedList = new LinkedList<T>();

        public void Enqueue(T item)
        {
            backingLinkedList.AddLast(item);
        }

        public T Dequeue()
        {
            if (backingLinkedList.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var item = backingLinkedList.First.Value;
            backingLinkedList.RemoveFirst();
            return item;
        }

        public T Peek()
        {
            if (backingLinkedList.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return backingLinkedList.First.Value;
        }

        public int Count()
        {
            return backingLinkedList.Count;
        }
    }
}
