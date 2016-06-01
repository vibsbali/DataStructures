using System;
using System.Collections;
using System.Collections.Generic;
using Core;

namespace ConcreteStructures
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public DoublyLinkedListNode<T> Head { get; private set; }
        public DoublyLinkedListNode<T> Tail { get; private set; }

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
            var current = Head;
            while (current != null)
            {
                array[arrayIndex] = current.Value;
                current = current.Next;
                arrayIndex++;
            }
        }

        public bool Remove(T item)
        {
            //start with setting up base case where current is head so previous is null
            DoublyLinkedListNode<T> current = Head;
            DoublyLinkedListNode<T> previous = null;    //This previous is local variable which tells us if we are at head or not

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    //This will mean the loop has run once and we are no longer at Head
                    //This also mean that the list contains more than one element
                    if (previous != null)
                    {
                        //If current.next is null then it means that is tail element
                        if (current.Next == null)
                        {
                            RemovedLast();
                            return true;
                        }
                        
                        //Otherwise it is going to be in the middle
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }
                    else //If it is null then it means it is head element
                    {
                        //Does list has only one item it means this is head and tail
                        if (Count == 1)
                        {
                            RemoveFirst();
                            return true;
                        }

                        Head = current.Next;
                        Head.Previous = null;
                    }

                    Count--;
                    return true;
                }

                //set previous to current and current to next item in the list
                previous = current;
                current = current.Next;
            }

            return false;
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
