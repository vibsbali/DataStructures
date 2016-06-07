using System;

namespace CoreNew
{
    public class Node<T> where T: IComparable<T>
    {
        public T Value { get; private set; }

        public Node(T value)
        {
            Value = value;
        }

        public Node<T> Next { get; set; }
    }
}
