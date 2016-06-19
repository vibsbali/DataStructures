using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreNew
{
    public class AvlTreeNode<T> 
        where T : IComparable<T>
    {
        public AvlTreeNode<T> Parent { get; private set; }
        public AvlTreeNode<T> Left { get; set; }
        public AvlTreeNode<T> Right { get; set; }

        public T Value { get; private set; }

        public AvlTreeNode(T value, AvlTreeNode<T> parent)
        {
            Parent = parent;
            Value = value;
        }
    }
}
