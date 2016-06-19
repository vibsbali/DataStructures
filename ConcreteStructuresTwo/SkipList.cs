using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using CoreNew;

namespace DataStructures
{
    public class SkipList<T> : ICollection<T> 
        where T : IComparable<T>
    {
        // used to determine the random height of the node links
        private readonly Random rand = new Random();

        //The non-data node which starts the list
        private SkipListNode<T> head; 

        //There is always one level of depth(the base list)
        private int levels = 1;

        // the number of items currently in the list
        public int Count { get; private set; }

        public SkipList()
        {
            head = head = new SkipListNode<T>(default(T), 32 + 1); //max could be 24 levels
        }

        public IEnumerator<T> GetEnumerator()
        {
            SkipListNode<T> cur = head.Next[0];
            while (cur != null)
            {
                yield return cur.Value;
                cur = cur.Next[0];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            int level = PickRandomLevel();

            //level + 1 will ensure that a minimum of 1 level is selected
            SkipListNode<T> newNode = new SkipListNode<T>(item, level + 1);

            SkipListNode<T> current = head;
            for (int i = levels - 1; i >= 0; i--)
            {
                while (current.Next[i] != null)
                {
                    if (current.Next[i].Value.CompareTo(item) > 0)
                    {
                        break;
                    }
                    current = current.Next[i];
                }
                if (i <= level)
                {
                    // adding "c" to the list: a -> b -> d -> e
                    // current is node b and current.Next[i] is d.

                    // 1. Link the new node (c) to the existing node (d)
                    // c.Next = d
                    newNode.Next[i] = current.Next[i];

                    // Insert c into the list after b
                    // b.Next = c
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
            head = head = new SkipListNode<T>(default(T), 32 + 1); //max could be 24 levels
            Count = 0;
        }
        

        public bool Contains(T item)
        {
            SkipListNode<T> cur = head;
            for (int i = levels - 1; i >= 0; i--)
            {
                while (cur.Next[i] != null)
                {
                    int cmp = cur.Next[i].Value.CompareTo(item);
                    if (cmp > 0)
                    {
                        // The value is too large, so go down one level
                        // and take smaller steps.
                        break;
                    }
                    if (cmp == 0)
                    {
                        // Found it!
                        return true;
                    }
                    cur = cur.Next[i];
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            int offset = 0;
            foreach (T item in this)
            {
                array[arrayIndex + offset++] = item;
            }
        }

        public bool Remove(T item)
        {
            SkipListNode<T> cur = head;
            bool removed = false;
            // Walk down each level in the list (make big jumps).
            for (int level = levels - 1; level >= 0; level--)
            {
                // While we're not at the end of the list:
                while (cur.Next[level] != null)
                {
                    // If we found our node,
                    if (cur.Next[level].Value.CompareTo(item) == 0)
                    {
                        // remove the node,
                        cur.Next[level] = cur.Next[level].Next[level];
                        removed = true;
                        // and go down to the next level (where
                        // we will find our node again if we're
                        // not at the bottom level).
                        break;
                    }
                    // If we went too far, go down a level.
                    if (cur.Next[level].Value.CompareTo(item) > 0)
                    {
                        break;
                    }
                    cur = cur.Next[level];
                }
            }            if (removed)
            {
                Count--;
            }
            return removed;
        }


        public
            bool IsReadOnly => false;
    }
}
