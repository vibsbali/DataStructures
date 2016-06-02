using System;
using System.Collections;
using System.Collections.Generic;

namespace ConcreteStructures
{
    public class ArrayList<T> : IList<T>
    {
        private T[] backingArray;

        public ArrayList() : this(0)
        {
        }

        public ArrayList(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("length");
            }

            backingArray = new T[length];
        }

        private void GrowArray()
        {
            int newLength = backingArray.Length == 0 ? 16 : backingArray.Length << 1;
            var newArray = new T[newLength];

            backingArray.CopyTo(newArray, 0);
            backingArray = newArray;
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
            if (backingArray.Length == Count)
            {
                GrowArray();
            }

            backingArray[Count++] = item;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (backingArray[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (backingArray[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
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

            if (backingArray.Length == Count)
            {
                GrowArray();
            }

            //Shift all the items following index one slot to the right
            Array.Copy(backingArray, index, backingArray, index + 1, Count - index);
            backingArray[index] = item;

            Count++;
        }

        public void RemoveAt(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            int shiftStart = index + 1;
            if (shiftStart < Count)
            {
                Array.Copy(backingArray, shiftStart, backingArray, index, Count - shiftStart);
            }
            Count--;
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
