/*
    Priority Queue is a very thin wrapper over a heap
*/

using System;

namespace DataStructures
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        Heap<T> heap = new Heap<T>();

        public void Enqueue(T value)
        {
            heap.Add(value);
        }

        public T Deque()
        {
            return heap.RemoveMax();
        }

        public void Clear()
        {
            heap.Clear();
        }

        public int Count => heap.Count;
    }
}
