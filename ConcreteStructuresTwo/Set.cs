using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace DataStructures
{
    public class Set<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly List<T> items = new List<T>();

        public Set()
        {
            
        }

        public Set(IEnumerable<T> items)
        {
            AddRange(items);
        }


        public void Add(T item)
        {
            if (items.Contains(item))
            {
                throw new InvalidOperationException("Item Already exists");
            }

            Add(item);
            Count++;
        }

        public bool Remove(T item)
        {
            if (items.Remove(item))
            {
                Count--;
                return true;
            }

            return false;
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public int Count { get; private set; }


        public Set<T> Union(Set<T> other)
        {
            var temp = new Set<T>(items);
            foreach (var item in other.Where(item => !other.Contains(item)))
            {
                temp.Add(item);
            }

            return temp;
        }

        public Set<T> Intersection(Set<T> other)
        {
            var temp = new Set<T>();
            foreach (var item in items)
            {
                if (other.Contains(item))
                {
                    temp.Add(item);
                }
            }

            return temp;
        }

        public Set<T> Difference(Set<T> other)
        {
            var temp = new Set<T>(items);
            foreach (var item in other)
            {
                temp.Remove(item);
            }

            return temp;
        }


        public Set<T> SymetricDifference(Set<T> other)
        {
            var union = Union(other);
            var intersection = Intersection(other);

            return union.Difference(intersection);
        } 

        private void AddRange(IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
            {
                Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
