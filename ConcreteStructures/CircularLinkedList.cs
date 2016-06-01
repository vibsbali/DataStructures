using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Core;

namespace ConcreteStructures
{
    public class CircularLinkedList<T> : ICollection<T>
    {
        public SinglyLinkedListNode<T> Head { get; private set; }
        public SinglyLinkedListNode<T> Tail { get; private set; }

        //Added a max size of 10 (default)
        public uint MaxSize { get; set; } = 10;

        public IEnumerator<T> GetEnumerator()
        {
            if (Head == null) yield break;

            if (Head == Tail)
            {
                yield return Head.Value;
            }
            else
            {
                var currentNode = Head;
                do
                {
                    yield return currentNode.Value;
                    currentNode = currentNode.Next;
                } while (currentNode != Head);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //This add items to end
        public void Add(T item)
        {
            //Added a while loop because MaxSize is a public property and can be changed dynamically
            while (Count >= MaxSize)
            {
                RemoveFirst();
            }

            if (Head == null)
            {
                Head = new SinglyLinkedListNode<T>(item);
                Tail = Head;
            }
            else
            {
                var node = new SinglyLinkedListNode<T>(item);
                Tail.Next = node;
                Tail = node;
            }

            Tail.Next = Head;
            Count++;
        }

        //Removing from the front because we have 
        public void RemoveFirst()
        {
            if (Count > 0)
            {
                if (Head == Tail)
                {
                    Clear();
                    return;
                }

                var item = Head.Next;
                Head = item;
                Count--;
            }
        }

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = Head;
            do
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                //else
                current = current.Next;
            } while (current != Head);

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = Head;
            do
            {
                array[arrayIndex] = current.Value;
                arrayIndex++;
                current = current.Next;
            } while (current != Head);
        }

        public bool Remove(T item)
        {
            if (Count == 0)
            {
                return false;
            }

            var current = Head;
            SinglyLinkedListNode<T> previous = null;

            do
            {
                if (current.Value.Equals(item))
                {
                    if (Head == Tail)
                    {
                        Clear();
                        return true;
                    }
                    if (previous != null)   //i.e. it is not head
                    {
                        if (current == Tail) //i.e. the tail is to be removed
                        {
                            Tail = previous;
                            Tail.Next = Head;
                            Count--;
                            return true;
                        }

                        previous.Next = current.Next;
                        Count--;
                        return true;
                    }
                    //if previous is null and current item is found then it has to be head
                    Head = current.Next;
                    Tail.Next = Head;
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            } while (current != Head);

            return false;
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }
}
