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
                    Rebalance(parentNode);
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
                    Rebalance(parentNode);
                    return;
                }
                InsertNode(value, parentNode.Right);
            }
        }

        private void Rebalance(AvlTreeNode<T> currentNode)
        {
            //while parent != null
            while (currentNode != null)
            {
                //check if node is balanced --
                
                // 1. Get number of left most child
                var leftWeight = currentNode.MaxLeftHeight;

                //2. Get number of right most child
                var rightWeight = currentNode.MaxRightHeight;

                //3. Get the difference
                var leftHeavy = leftWeight - rightWeight;
                
                //4. Is the difference greater than 1
                if (leftHeavy < -1)
                {
                    //Right is heavy
                    Console.WriteLine("Right is heavy");
                    //Instead of currentNode.Right.MaxLeftHeight > currentNode.Right.MaxRightHeight
                    if (currentNode.Right.MaxLeftHeight > currentNode.Right.MaxRightHeight)
                    {
                        LeftRightRotation(currentNode);
                    }
                    else
                    {
                        LeftRotation(currentNode);
                    }
                    break;
                }
                if (leftHeavy > 1)
                {
                    //left is heavy
                    Console.WriteLine("Left is heavy");
                    //Instead of currentNode.Left.MaxLeftHeight < currentNode.Left.MaxRightHeight
                    if (currentNode.Left.MaxRightHeight > currentNode.Left.MaxLeftHeight)
                    {
                        RightLeftRotation(currentNode);
                    }
                    else
                    {
                        RightRotation(currentNode);
                    }
                    break;
                }

                //Is it root that is going to be updated
                //If so update root

                currentNode = currentNode.Parent;
            }
        }

        private void RightRotation(AvlTreeNode<T> currentNode)
        {
            var newRoot = currentNode.Left;
            ReplaceRoot(newRoot, currentNode);
            currentNode.Left = newRoot.Right;
            newRoot.Right = currentNode;
        }

        private void RightLeftRotation(AvlTreeNode<T> currentNode)
        {
            LeftRotation(currentNode.Left);
            RightRotation(currentNode);   
        }

        private void LeftRotation(AvlTreeNode<T> currentNode)
        {
            var newRoot = currentNode.Right;
            ReplaceRoot(newRoot, currentNode);
            currentNode.Right = newRoot.Left;
            newRoot.Left = currentNode;
        }

        private void ReplaceRoot(AvlTreeNode<T> newRoot, AvlTreeNode<T> oldRoot)
        {
            if (oldRoot.Parent == null) //i.e. this is Head node
            {
                Head = newRoot;
            }
            else
            {
                //this is going from current node to its parent and then going from parent back to left 
                if (oldRoot.Parent.Left.Value.CompareTo(oldRoot.Value) == 0) //the old root was left child of parent
                {
                    oldRoot.Parent.Left = newRoot;
                }
                else
                {
                    oldRoot.Parent.Right = newRoot;
                }
            }

            newRoot.Parent = oldRoot.Parent;
            oldRoot.Parent = newRoot;
        }

        private void LeftRightRotation(AvlTreeNode<T> currentNode)
        {
            RightRotation(currentNode.Right);
            LeftRotation(currentNode);   
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
