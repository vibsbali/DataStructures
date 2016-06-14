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


        private BinaryTreeNode<T> FindWithParent(BinaryTreeNode<T> node, T item, out BinaryTreeNode<T> parentNode)
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
                    return current;
                }
            }

            return null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            BinaryTreeNode<T> parent;
            var result = FindWithParent(Root, item, out parent);

            if (result != null)
            {
                //Is it a tail node
                if (result.Left == null && result.Right == null)
                {
                    parent.Left = null;
                    parent.Right = null;
                }
                //If Node to remove has no Right child
                if (result.Right == null)
                {
                    //Check if it is right or left 
                    //If parent is larger then it means it is left
                    if (parent.Value.CompareTo(result.Value) > 0)
                    {
                        parent.Left = result.Left;
                    }
                    else
                    {
                        parent.Right = result.Left;
                    }
                }
                //If Node to remove has a right child has no left child
                else if (result.Right.Left == null)
                {
                    //Check if it is right or left 
                    //If parent is larger then it means it is left
                    if (parent.Value.CompareTo(result.Value) > 0)
                    {
                        var nodeToRemove = result;
                        parent.Left = null;
                        parent.Left = result.Right;
                        parent.Left.Left = nodeToRemove.Left;
                    }
                    else
                    {
                        var nodeToRemove = result;
                        parent.Right = null;
                        parent.Right = result.Right;
                        parent.Right.Left = nodeToRemove.Left;
                    }
                }
                //The node to be removed has a right child which, in turn, has a left child.
                //In this case, the left-most child of the removed node’s right child must be placed into the removed node’s slot
                else if (result.Right.Left != null)
                {
                    //Check if it is right or left 
                    //If parent is larger then it means it is left
                    if (parent.Value.CompareTo(result.Value) > 0)
                    {
                        var nodeToRemove = result;
                        parent.Left = null;
                        parent.Left = FindLeftMostNode(result.Right);
                        parent.Left.Left = nodeToRemove.Left;
                        parent.Left.Right = nodeToRemove.Right;
                    }
                    else
                    {
                        var nodeToRemove = result;
                        parent.Right = null;
                        parent.Right = FindLeftMostNode(result.Right);
                        parent.Right.Left = nodeToRemove.Left;
                        parent.Right.Right = nodeToRemove.Right;
                    }
                }
                Count--;
                return true;
            }

            return false;
        }



        private IEnumerator<T> InOrderTraversal()
        {
            // This is a non-recursive algorithm using a stack to demonstrate removing // recursion. 
            if (Root != null)
            {
                // Store the nodes we've skipped in this stack (avoids recursion). 
                System.Collections.Generic.Stack<BinaryTreeNode<T>> stack = new System.Collections.Generic.Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> current = Root;

                // When removing recursion, we need to keep track of whether we should be going to the left node or the right nodes next. 
                bool goLeftNext = true;

                // Start by pushing Head onto the stack. 
                stack.Push(current);

                while (stack.Count > 0)
                {
                    // If we're heading left... 
                    if (goLeftNext)
                    {
                        // Push everything but the left-most node to the stack. We'll yield the left-most after this block. 
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    // Inorder is left->yield->right. 

                    yield return current.Value;

                    // If we can go right, do so. 
                    if (current.Right != null)
                    {
                        current = current.Right;

                        // Once we've gone right once, we need to start going left again. 
                        goLeftNext = true;
                    }
                    else
                    {
                        // If we can't go right, then we need to pop off the parent node so we can process it and then go to its right node. 
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, Root);

        }

        private void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
            }
        }
        

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, Root);
        }

        private void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, Root);
        }

        private void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(action, node.Left);
                action(node.Value);
                InOrderTraversal(action, node.Right);
            }
        }


        private BinaryTreeNode<T> FindLeftMostNode(BinaryTreeNode<T> node)
        {
            var previous = node;
            while (node != null)
            {
                previous = node;
                node = node.Left;
            }
            return previous;
        }

        private void Insert(BinaryTreeNode<T> node, T item)
        {
            //If LHS < RHS
            Console.WriteLine(node.Value.CompareTo(item));
            if (node.Value.CompareTo(item) == 1)
            {
                if (node.Left != null)
                {
                    Insert(node.Left, item);
                }
                else
                {
                    node.Left = new BinaryTreeNode<T>(item);
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
                }
            }
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
