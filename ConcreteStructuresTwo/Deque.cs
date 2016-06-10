using System;

namespace DataStructures
{
    public class Deque<T>
    {
        System.Collections.Generic.LinkedList<T> items = new System.Collections.Generic.LinkedList<T>();

        //Complexity O(1) constant
        public void EnqueueFirst(T value)
        {
            items.AddFirst(value);
        }

        //Complexity O(1) constant
        public void EnqueueLast(T value)
        {
            items.AddLast(value);
        }

        //Complexity O(1) constant
        public T DequeueFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot Dequeue on empty Deque");
            }

            var itemToReturn = items.First;
            items.RemoveFirst();

            return itemToReturn.Value;
        }

        //Complexity O(1) constant
        public T DequeueLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot Dequeue on empty Deque");
            }

            var itemToReturn = items.Last;
            items.RemoveLast();

            return itemToReturn.Value;
        }

        //Complexity O(1) constant
        public T PeekFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("PeekFirst called when deque is empty");
            }

            return items.First.Value;
        }

        //Complexity O(1) constant
        public T PeekLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("PeekLast called when deque is empty");
            }

            return items.Last.Value;
        }

        public int Count => items.Count;
    }
}
