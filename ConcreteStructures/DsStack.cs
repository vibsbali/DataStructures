using System;
using System.Collections.Generic;

namespace ConcreteStructures
{
    public class DsStack<T> 
    {
        private LinkedList<T> backingLinkedList = new LinkedList<T>();

        public void Push(T item)
        {
            backingLinkedList.AddLast(item);
        }

        public T Pop()
        {
            if (backingLinkedList.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var item = backingLinkedList.Last.Value;
            backingLinkedList.RemoveLast();
            return item;
        }

        public T Peek()
        {
            if (backingLinkedList.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return backingLinkedList.Last.Value;
        }

        public int Count()
        {
            return backingLinkedList.Count;
        }
    }
}
