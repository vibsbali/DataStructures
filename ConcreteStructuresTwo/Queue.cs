using System;

namespace DataStructures
{
    public class Queue<T>
    {
        private System.Collections.Generic.LinkedList<T> items = new System.Collections.Generic.LinkedList<T>();

        public void Enqueue(T item)
        {
            items.AddLast(item);
        }

        public T Dequeue()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            var itemToReturn = items.First.Value;
            items.RemoveFirst();

            return itemToReturn;
        }

        public T Peek()
        {
            return items.First.Value;
        }
    }
}
