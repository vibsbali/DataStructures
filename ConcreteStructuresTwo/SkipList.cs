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
            int level = PickRandomLevel();

            var newNode = new SkipListNode<T>(item, level + 1);
            var current = head;

            for (int i = level; i >= 0; i--)
            {
                while (current.Next[i] != null)
                {
                    //LHS > RHS
                    if (current.Next[i].Value.CompareTo(item) > 0)
                    {
                        break;
                    }

                    current = current.Next[i];
                }

                if (i <= level)
                {
                    //Adding "c" to the list: a -> b -> d -> e
                    //Current is node b and current.Next[i] is d

                    //1. Link the new node (c) to existing node (d) :
                    //c.Next = d
                    newNode.Next[i] = current.Next[i];

                    //Insert c into the list after b:
                    //b.Next = c
                    current.Next[i] = newNode;
                }
            }

            Count++;
        }

        private int PickRandomLevel()
        {
            int random = rand.Next();
            int level = 0;

            // We're using the bit mask of a random integer to determine if the max
            // level should increase by one or not.
            // Say the 8 LSBs of the int are 00101100. In that case, when the
            // LSB is compared against 1, it tests to 0 and the while loop is never
            // entered so the level stays the same. That should happen 1/2 of the time.
            // Later, if the _levels field is set to 3 and the rand value is 01101111,
            // the while loop will run 4 times and on the last iteration will
            // run another 4 times, creating a node with a skip list height of 4. This should
            // only happen 1/16 of the time.
            while ((random & 1) == 1)
            {
                if (level == levels)
                {
                    levels++;
                    break;
                }

                random >>= 1;
                level++;
            }

            return level;
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
