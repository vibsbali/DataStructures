using System;
using System.Collections;
using System.Collections.Generic;
using CoreNew;

namespace DataStructures
{
    public class DoublyLinkedList<T> : ICollection<T>
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
                temp.Previous = Head;
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
                node.Previous = Tail;
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

            if (Head == Tail)
            {
                Clear();
                return;
            }
            var newHead = Head.Next;
            newHead.Previous = null;
            Head = null;                //When nulling the object all the related references will be nulled too
            Head = newHead;
            Count--;
        }

        //Remove from back is not an operation of LinkedList in Production O(1) 
        public void RemoveFromBack()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Cannot call remove on Empty Linked List");
            }

            //i.e. there only one element
            if (Head == Tail)
            {
                Clear();
                return;
            }
            Tail = Tail.Previous;
            Tail.Next = null;
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


        public void Add(T item)
        {
            AddToBack(new DoublyNode<T>(item));
        }

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (FindAndRetrieve(item) == null)
            {
                return false;
            }

            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = Head;
            while (current.Next != null)
            {
                array[arrayIndex] = current.Value;
                arrayIndex = arrayIndex + 1;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            var foundItem = FindAndRetrieve(item);

            if (foundItem != null)
            {
                if (foundItem == Head)
                {
                    RemoveFromFront();
                }
                else if (foundItem == Tail)
                {
                    RemoveFromBack();
                }
                else
                {
                    var previousNode = foundItem.Previous;
                    var nextNode = foundItem.Next;

                    previousNode.Next = nextNode;
                    nextNode.Previous = previousNode;
                }

                return true;
            }

            return false;
        }

        public int Count { get; set; }
        public bool IsReadOnly => false;

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
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

        private DoublyNode<T> FindAndRetrieve(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (item.Equals(current.Value))
                {
                    return current;
                }
                current = current.Next;
            }

            return null;
        } 
    }
}
