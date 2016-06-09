using System;

namespace DataStructures
{
    public class Stack<T>
    {
        readonly System.Collections.Generic.LinkedList<T> items = new System.Collections.Generic.LinkedList<T>();

        public int Count { get; private set; }

        public void Push(T item)
        {
            items.AddLast(item);
            Count++;
        }

        public T Pop()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            var item = items.Last;
            items.RemoveLast();
            Count--;

            return item.Value;
        }

        public T Peek()
        {
            return items.Last.Value;
        }
    }
}
