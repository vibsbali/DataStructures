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

        //The cost of doubling the array is amortized over the adding process therefore the Add method's complexity is O(1)
        private void GrowArray()
        {
            int newLength = backingArray.Length == 0 ? 16 : backingArray.Length << 1;
            var newArray = new T[newLength];

            backingArray.CopyTo(newArray, 0);
            backingArray = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
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

            backingArray[Count++] = item;
        }

        public void Clear()
        {
            backingArray = new T[0];
            Count = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(backingArray, 0, array, arrayIndex, Count);
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

        public bool IsReadOnly => false;

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
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
            get
            {
                if (index < Count)
                {
                    return backingArray[index];
                }

                throw new IndexOutOfRangeException();
            }

            set
            {
                if (index < Count)
                {
                    backingArray[index] = value;
                }

                throw new IndexOutOfRangeException();
            }
        }
    }
}
