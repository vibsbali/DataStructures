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
                    break;
                }
                if (leftHeavy > 1)
                {
                    //left is heavy
                    Console.WriteLine("Left is heavy");
                    break;
                }

                //Is it root that is going to be updated
                //If so update root

                currentNode = currentNode.Parent;
            }
        }

        private void RightRotation(AvlTreeNode<T> currentNode)
        {

        }

        private void RightLeftRotation(AvlTreeNode<T> currentNode)
        {

        }

        private void LeftRotation(AvlTreeNode<T> currentNode)
        {

        }

        private void LeftRightRotation(AvlTreeNode<T> currentNode)
        {
            
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
