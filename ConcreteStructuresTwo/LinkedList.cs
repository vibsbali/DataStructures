using System;
using System.Collections;
using System.Collections.Generic;
using CoreNew;

namespace ConcreteStructuresTwo
{
    public class LinkedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public void AddToFront(Node<T> node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                var temp = Head;
                Head = node;
                Head.Next = temp;
            }

            Count++;
        }

        public void AddToBack(Node<T> node)
        {
            if (Tail == null)
            {
                Tail = node;
                Head = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }

            Count++;
        }


        public int Count { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
