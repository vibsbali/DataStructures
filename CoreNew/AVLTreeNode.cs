using System;

namespace CoreNew
{
    public class AvlTreeNode<T> 
        where T : IComparable<T>
    {
        public AvlTreeNode<T> Parent { get; private set; }
        public AvlTreeNode<T> Left { get; set; }
        public AvlTreeNode<T> Right { get; set; }

        public T Value { get; private set; }

        public int MaxLeftHeight => FindLeftWeight(this);
        public int MaxRightHeight => FindRightWeight(this);

        public AvlTreeNode(T value, AvlTreeNode<T> parent)
        {
            Parent = parent;
            Value = value;
        }

        private int FindLeftWeight(AvlTreeNode<T> node)
        {
            var weight = 0;
            while (node.Left != null)
            {
                weight++;
                node = node.Left;
            }
            return weight;
        }

        private int FindRightWeight(AvlTreeNode<T> node)
        {
            var weight = 0;
            if (node.Right != null)
            {
                weight++;
                FindRightWeight(node.Right);
            }
            return weight;
        }
    }
}
