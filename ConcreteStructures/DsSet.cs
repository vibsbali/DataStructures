using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ConcreteStructures
{
    public class DsSet<T> : IEnumerable<T>
            where T : IComparable<T>
    {
        public List<T> backingStore { get; set; }

        public DsSet()
        {
            
        }

        public DsSet(IEnumerable<T> items)
        {
            AddRange(items);
        }

        private void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void Add(T item)
        {
            if (Contains(item))
            {
                throw new InvalidOperationException("Item already exists in set");
            }

            backingStore.Add(item);
        }

        private bool Contains(T item)
        {
            return backingStore.Contains(item);
        }

        public bool Remove(T item)
        {
            return backingStore.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
