using System;
using System.Collections;
using System.Collections.Generic;

namespace ConcreteStructures
{
    public class ArrayList<T> : IList<T>
    {
        private T[] items;

        public ArrayList() : this(0)
        {
        }

        public ArrayList(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("length");
            }

            items = new T[length];
        }

        private void GrowArray()
        {
            int newLength = items.Length == 0 ? 16 : items.Length << 1;
            var newArray = new T[newLength];

            items.CopyTo(newArray, 0);
            items = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (items.Length == Count)
            {
                GrowArray();
            }

            //Shift all the items following index one slot to the right
            Array.Copy(items, index, items, index + 1, Count - index);
            items[index] = item;

            Count++;
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
