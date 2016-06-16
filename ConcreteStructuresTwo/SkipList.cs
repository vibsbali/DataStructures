using System;
using System.Collections;
using System.Collections.Generic;
using CoreNew;

namespace DataStructures
{
    public class SkipList<T> : ICollection<T> 
        where T : IComparable<T>
    {
        private readonly Random rand = new Random();

        //The non-data node which starts the list
        private SkipListNode<T> head; 

        //There is always one level of depth(the base list)
        private int levels = 1;


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
            int levels = PickRandomLevel();

            var newNode = new SkipListNode<T>(item, levels + 1);
            var current = head;

            for (int i = levels; i >= 0; i--)
            {
                
            }
        }

        private int PickRandomLevel()
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
    }
}
