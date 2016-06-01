using System;
using System.Collections;
using System.Collections.Generic;
using Core;

namespace ConcreteStructures
{
    public class LinkList<T> : ICollection<T>
    {
        private LinkListNode<T> Head { get; set; } 
        private LinkListNode<T> Tail { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            LinkListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            var node = new LinkListNode<T>(item);

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }

            Count++;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            if (Count == 0)
            {
                return false;
            }

            LinkListNode<T> previous = null;
            LinkListNode<T> current = Head;


            //Keep looping until end of linked list i.e. until null is found
            while (current != null)
            {
                //if found do something
                if (current.Value.Equals(item))
                {
                    //if it is in middle
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        //If it is tail update Tail
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                    }
                    else
                    {
                        Head = Head.Next;
                        if (Head == null)
                        {
                            Tail = null;
                        }
                    }

                    Count--;
                    return true;
                }


                //Since it is a single linked list we keep on moving the previous pointer to current and move current to next node
                previous = current;
                current = current.Next;
            }

            return false;
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get; }
    }
}
