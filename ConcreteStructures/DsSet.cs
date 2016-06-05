using System;
using System.Collections;
using System.Collections.Generic;

namespace ConcreteStructures
{
    public class DsSet<T> : IEnumerable<T>
            where T : IComparable<T>
    {
        private List<T> BackingStore { get; set; }

        public DsSet()
        {
            BackingStore = new List<T>();
        }

        public DsSet(IEnumerable<T> items)
        {
            BackingStore = new List<T>();
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

            BackingStore.Add(item);
        }

        private bool Contains(T item)
        {
            return BackingStore.Contains(item);
        }

        public bool Remove(T item)
        {
            return BackingStore.Remove(item);
        }

        public int Count => BackingStore.Count;

        public IEnumerator<T> GetEnumerator()
        {
            return BackingStore.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
