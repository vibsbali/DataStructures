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
            //We will set the incoming node as the parent node
            var parent = binaryTreeNode;
            //check if the item to add is less than node's value
            if (item.CompareTo(binaryTreeNode.Value) < 0)
            {
                //if there is no left child, make this the new left child
                if (binaryTreeNode.Left == null)
                {
                    binaryTreeNode.Left = new BinaryTreeNode<T>(item)
                    {
                        Parent = parent
                    };
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
                    binaryTreeNode.Right = new BinaryTreeNode<T>(item)
                    {
                        Parent = parent
                    };
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
            if (head == null)
            {
                return false;
            }
            else
            {
               return FindWithParent(head, item);
            }
        }

        private bool FindWithParent(BinaryTreeNode<T> binaryTreeNode, T item)
        {
            if (binaryTreeNode == null)
            {
                return false;
            }

            if (item.CompareTo(binaryTreeNode.Value) == 0)
            {
                return true;
            }
            if(item.CompareTo(binaryTreeNode.Value) < 0)
            {                
                return FindWithParent(binaryTreeNode.Left, item);
            }

            return FindWithParent(binaryTreeNode.Right, item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            BinaryTreeNode<T> current, parent;

            current = FindWithParent(current, item);
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;
    }
}
