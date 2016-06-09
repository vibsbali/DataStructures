using System;

namespace DataStructures
{
    public class Deque<T>
    {
        LinkedList<T> items = new LinkedList<T>();

        public void EnqueueFirst(T value)
        {
            throw new NotImplementedException();
        }

        public void EnqueueLast(T value)
        {
            throw new NotImplementedException();
        }

        public T DequeueFirst()
        {
            throw new NotImplementedException();
        }

        public T DequeueLast()
        {
            throw new NotImplementedException();
        }

        public T PeekFirst()
        {
            throw new NotImplementedException();
        }

        public T PeekLast()
        {
            throw new NotImplementedException();
        }

        public int Count { get;  }
    }
}
