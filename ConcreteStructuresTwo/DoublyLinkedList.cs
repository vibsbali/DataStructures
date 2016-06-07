using System;
using System.Collections;
using System.Collections.Generic;
using CoreNew;

namespace ConcreteStructuresTwo
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public DoublyNode<T> Head { get; set; }
        public DoublyNode<T> Tail { get; set; }

        public void AddToFront(DoublyNode<T> node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = Head;
            }
            else
            {
                var temp = Head;
                Head = node;
                Head.Next = temp;
            }

            Count++;
        }

        public void AddToBack(DoublyNode<T> node)
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

        //Complexity O(1)
        public void RemoveFromFront()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Cannot call remove on Empty Linked List");
            }

            var newHead = Head.Next;
            Head = newHead;
            Count--;
        }

        //Remove from back is not an operation of LinkedList in Production O(N) where N is number of items - 1
        public void RemoveFromBack()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Cannot call remove on Empty Linked List");
            }

            //There is an alternative to this which is to move till Tail pointer like so
            //DoublyNode<T> current = head;
            //while(current.Next != Tail) { current = current.Next; }
            var secondLastItem = GetDoublyNodeAtIndex(Count - 2);
            secondLastItem.Next = null;
            Tail = secondLastItem;
            Count--;
        }

        public DoublyNode<T> GetDoublyNodeAtIndex(int index)
        {
            if (index > Count)
            {
                throw new IndexOutOfRangeException("Maximum index found to be " + Count);
            }

            var currentDoublyNode = Head;
            for (int i = 0; i < index; i++)
            {
                currentDoublyNode = currentDoublyNode.Next;
            }

            return currentDoublyNode;
        }


        public int Count { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != Tail)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
