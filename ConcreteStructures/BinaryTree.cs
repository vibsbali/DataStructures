using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace ConcreteStructures
{
    public class BinaryTree<T> : ICollection<T>
            where T : IComparable<T>
    {
        private BinaryTreeNode<T> head;  

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (head == null)
            {
                head = new BinaryTreeNode<T>(item);
            }
            else
            {
                AddTo(head, item);
            }

            Count++;
        }

        private void AddTo(BinaryTreeNode<T> binaryTreeNode, T item)
        {
            //check if the item to add is less than node's value
            if (item.CompareTo(binaryTreeNode.Value) < 0)
            {
                //if there is no left child, make this the new left child
                if (binaryTreeNode.Left == null)
                {
                    binaryTreeNode.Left = new BinaryTreeNode<T>(item);
                }
                else
                {
                    //Otherwise recursively call AddTo with the node and item to add
                    AddTo(binaryTreeNode.Left, item);
                }
            }
            //value is equal to or greater than the current value
            else
            {
                if (binaryTreeNode.Right == null)
                {
                    binaryTreeNode.Right = new BinaryTreeNode<T>(item);
                }
                else
                {
                    //else add to the right node by recursively calling AddTo
                    AddTo(binaryTreeNode.Right, item);
                }
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;
    }
}
