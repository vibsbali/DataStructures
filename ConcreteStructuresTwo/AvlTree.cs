using System;
using System.Collections;
using System.Collections.Generic;
using CoreNew;

namespace DataStructures
{
    public class AvlTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public AvlTreeNode<T> Head { get; private set; }

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new AvlTreeNode<T>(value, null);
            }
            else
            {
                InsertNode(value, Head);
            }
            Count++;
        }

        private void InsertNode(T value, AvlTreeNode<T> parentNode)
        {
            //Is LHS > RHS - go left
            if (parentNode.Value.CompareTo(value) > 0)
            {
                if (parentNode.Left == null)
                {
                    parentNode.Left = new AvlTreeNode<T>(value, parentNode);
                    return;
                }
                InsertNode(value, parentNode.Left);
            }
            //Otherwise LHS <= RHS - go right
            else
            {
                if (parentNode.Right == null)
                {
                    parentNode.Right = new AvlTreeNode<T>(value, parentNode);
                    return;
                }
                InsertNode(value, parentNode.Right);
            }
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            
        }

        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
