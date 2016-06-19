using System;

namespace DataStructures
{
    public class Heap<T> where T: IComparable<T>
    {
        private T[] items;
        public int Count { get; private set; }

        public readonly int DefaultLength;

        public Heap() : this(100)
        {
        }

        public Heap(int length)
        {
            DefaultLength = length;
            Count = 0;
        }

        public void Add(T value)
        {
            
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public T RemoveMax()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            items = new T[DefaultLength];
            Count = 0;
        }

        private int Parent(int index)
        {
            throw new NotImplementedException();
        }

        private void Swap(int left, int right)
        {
            var temp = items[left];
            items[left] = items[right];
            items[right] = temp;
        }
    }
}
