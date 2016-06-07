using System;

namespace CoreNew
{
    public class Node<T> where T: IComparable<T>
    {
        private Node<T> next;    
        public T Value { get; private set; }
      
        public Node(T value)
        {
            Value = value;
        }

        public Node<T> Next
        {
            get { return next; }

            set
            {
                if (value == this)
                {
                    throw new InvalidOperationException("Cant point node to itself");
                }

                next = value;
            }
        }
    }
}
