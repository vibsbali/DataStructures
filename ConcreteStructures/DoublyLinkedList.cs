using System;
using System.Collections;
using System.Collections.Generic;
using Core;

namespace ConcreteStructures
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        private DoublyLinkedListNode<T> Head { get; set; }
        private DoublyLinkedListNode<T> Tail { get; set; } 


        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current.Value;

                current.Previous = current;
                current = current.Next;
            }
        }

        public void AddFirst(T value)
        {
            var node = new DoublyLinkedListNode<T>(value);

            //Save off the head
            var temp = Head;

            //Set Head to new node
            Head = node;

            //Set next pointer to temp
            Head.Next = temp;

            //If it is the only item in the list
            if (Count == 0)
            {
                Tail = Head;
            }
            else
            {
                temp.Previous = Head;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            var node = new DoublyLinkedListNode<T>(value);

            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
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
                current.Previous = current;
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
            throw new NotImplementedException();
        }

        public void RemoveFirst()
        {
            //Remove head if count is not 0
            if (Count == 0) return;

            var node = Head;
            Head = node.Next;
            Count--;

            if (Count == 0)
            {
                Tail = null;
            }
            else
            {
                Head.Previous = null;
            }
        }

        public void RemovedLast()
        {
            //start from end and check if item exists
            if (Count == 0) return;

            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                var node = Tail;
                Tail = node.Previous;
                Tail.Next = null;
            }
            Count--;
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;
    }
}
