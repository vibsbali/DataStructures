using System;
using System.Collections;
using System.Collections.Generic;


namespace DataStructures
{
    internal class BinaryTreeNode<T>
        where T : IComparable<T>
    {
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public T Value { get; private set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }
    }


    public class Tree<T> : ICollection<T>
            where T : IComparable<T>
    {
        private BinaryTreeNode<T> Root { get; set; }

        public void Add(T item)
        {
            if (Root == null)
            {
                Root = new BinaryTreeNode<T>(item);
            }
            else
            {
                Insert(Root, item);
            }

            Count++;
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Find(Root, item);
        }

        //Also look at FindWithParent which shows how a recursive call can be changed to while loop
        private bool Find(BinaryTreeNode<T> node, T item)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value.CompareTo(item) == -1)
            {
                return Find(node.Right, item);
            }
            if (node.Value.CompareTo(item) == 1)
            {
                return Find(node.Left, item);
            }

            //If come this far we have found a match
            return true;
        }


        private bool FindWithParent(BinaryTreeNode<T> node, T item, out BinaryTreeNode<T> parentNode)
        {
            var current = node;
            parentNode = null;

            while (current != null)
            {
                if (current.Value.CompareTo(item) < 0)
                {
                    parentNode = current;
                    current = current.Right;
                }
                else if (current.Value.CompareTo(item) > 0)
                {
                    parentNode = current;
                    current = current.Left;
                }
                else if (current.Value.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            BinaryTreeNode<T> parent;
            var result = FindWithParent(Root, item, out parent);

            return result;
        }

        private void Insert(BinaryTreeNode<T> node, T item)
        {
            //If LHS < RHS
            Console.WriteLine(node.Value.CompareTo(item));
            if (node.Value.CompareTo(item) > -1)
            {
                if (node.Left != null)
                {
                    Insert(node.Left, item);
                }
                else
                {
                    node.Left = new BinaryTreeNode<T>(item);
                    Count++;
                }
            }
            else
            {
                if (node.Right != null)
                {
                    Insert(node.Right, item);
                }
                else
                {
                    node.Right = new BinaryTreeNode<T>(item);
                    Count++;
                }
            }
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;

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
