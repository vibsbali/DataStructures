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

        public DsSet<T> Union(DsSet<T> other)
        {
            var firstSet = new DsSet<T>(BackingStore);

            foreach (var item in other)
            {
                if (!firstSet.Contains(item))
                {
                    firstSet.Add(item);
                }
            }

            return firstSet;
        }

        public DsSet<T> Intersection(DsSet<T> other)
        {
            var setToReturn = new DsSet<T>();
            foreach (var item in BackingStore)
            {
                if (other.BackingStore.Contains(item))
                {
                    setToReturn.Add(item);
                }
            }

            return setToReturn;
        }

        public DsSet<T> Difference(DsSet<T> other)
        {
            var setToReturn = new DsSet<T>(BackingStore);

            foreach (var item in setToReturn)
            {
                if (other.BackingStore.Contains(item))
                {
                    setToReturn.Remove(item);
                }
            }

            return setToReturn;
        }   


    }
}
