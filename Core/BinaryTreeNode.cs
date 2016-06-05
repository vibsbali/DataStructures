using System;

namespace Core
{
    public class BinaryTreeNode<T> : IComparable<T> 
                 where T : IComparable<T>
    {
        public T Value { get; }

        public BinaryTreeNode<T> Parent { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }
    }
}
