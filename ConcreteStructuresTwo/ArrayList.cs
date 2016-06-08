using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class ArrayList<T> : IList<T>
    {
        private T[] backingArray;
        //Min length is sixteen
        private const int InitialSize = 16;

        public ArrayList(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("length");
            }

            backingArray = new T[length];
        }
        
        public ArrayList() : this(InitialSize)
        {
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return backingArray[i];
            }
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
            backingArray[Count] = item;
            ++Count;
        }

        //This is a private method that grows backing array
        private void GrowArray()
        {
            var temp = new T[backingArray.Length * 2];
            backingArray.CopyTo(temp, 0);
            backingArray = temp;
        }

        public void Clear()
        {
            backingArray = new T[InitialSize];
            Count = 0;
        }

        public bool Contains(T item)
        {
            for (var i = 0; i < backingArray.Length; i++)
            {
                var value = backingArray[i];
                if (value.Equals(item))
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
            var indexOfItem = IndexOf(item);
            if (indexOfItem >= 0)
            {
                RemoveAt(indexOfItem);
                return true;
            }

            return false;
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public int IndexOf(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (backingArray[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }
            Array.Copy(backingArray, index + 1, backingArray, index, Count - index);
            Count--;
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
