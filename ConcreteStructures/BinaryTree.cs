using System;
using System.Collections;
using System.Collections.Generic;
using Core;

namespace ConcreteStructures
{
    public class BinaryTree<T> : ICollection<T>
            where T : IComparable<T>
    {
        public BinaryTreeNode<T> Head { get; private set; }

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
            if (Head == null)
            {
                Head = new BinaryTreeNode<T>(item);
            }
            else
            {
                AddTo(Head, item);
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
            Head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (Head == null)
            {
                return false;
            }

            return FindNode(Head, item) != null;
        }

        private BinaryTreeNode<T> FindNode(BinaryTreeNode<T> binaryTreeNode, T item)
        {
            if (binaryTreeNode == null)
            {
                return null;
            }

            if (item.CompareTo(binaryTreeNode.Value) == 0)
            {
                return binaryTreeNode;
            }
            if (item.CompareTo(binaryTreeNode.Value) < 0)
            {
                return FindNode(binaryTreeNode.Left, item);
            }

            return FindNode(binaryTreeNode.Right, item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            //Find the node if present starting from head
            var nodeToRemove = FindNode(Head, item);

            //If nothing found
            if (nodeToRemove == null)
            {
                return false;
            }

            //If we have passed the previous check then, it means that we have found the node to be removed so count--
            Count--;

            if (Count == 0)//i.e. Head to be removed
            {
                Clear();    //Call Clear
            }

            //Case 1: If node to remove has no right child, current's left replaces current
            if (nodeToRemove.Right == null)
            {
                var parent = nodeToRemove.Parent;   //get a reference of parent
                var nodeToMoveInPlace = nodeToRemove.Left; //get a reference to the node that is going into place of removed node

                parent.Left = nodeToMoveInPlace;    //update parent's left node
                nodeToMoveInPlace.Parent = parent;  //update node's parent pointer
                return true;
            }
            //Case 2: If node to remove has a right child which, in turn, has no left child
            if (nodeToRemove.Right.Left == null)
            {
                var parent = nodeToRemove.Parent;
                var nodeToMoveInPlace = nodeToRemove.Right;

                parent.Left = nodeToMoveInPlace;
                nodeToMoveInPlace.Parent = parent;

                //fix moved node's left child
                nodeToMoveInPlace.Left = nodeToRemove.Left;
                nodeToRemove.Left.Parent = nodeToMoveInPlace;

                return true;
            }
            //Case 3: If node to remove has a right child which, in turn, has a left child
            if (nodeToRemove.Right.Left != null)
            {
                var parent = nodeToRemove.Parent;
                var nodeToMoveInPlace = FindLeftMostNode(nodeToRemove.Right);
                var parentOfNodeToMoveInPlace = nodeToMoveInPlace.Parent;

                //update parent references
                parent.Left = nodeToMoveInPlace;
                nodeToMoveInPlace.Parent = parent;
                
                //fix moved node's left child
                nodeToMoveInPlace.Left = nodeToRemove.Left;
                nodeToRemove.Left.Parent = nodeToMoveInPlace;

                //fix moved node's right child
                nodeToMoveInPlace.Right = nodeToRemove.Right;

                parentOfNodeToMoveInPlace.Left = null;

                return true;
            }

            throw new Exception("Unknown case found"); //Intentionally throwing an error if none of the above case is found
        }

        private BinaryTreeNode<T> FindLeftMostNode(BinaryTreeNode<T> current)
        {
            while (current.Left != null)
            {
                FindLeftMostNode(current.Left);
            }

            return current;
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;
    }
}
