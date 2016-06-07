using System;

namespace CoreNew
{
    public class DoublyNode<T>
    {
        private DoublyNode<T> next;
        private DoublyNode<T> previous;
         
        public T Value { get; private set; }

        public DoublyNode(T value)
        {
            Value = value;
        }

        public DoublyNode<T> Next
        {
            get { return next; }

            set
            {
                if (value == this)
                {
                    throw new InvalidOperationException("Cant point DoublyNode to itself");
                }

                next = value;
            }
        }

        public DoublyNode<T> Previous
        {
            get { return previous; }

            set
            {
                if (value == this)
                {
                    throw new InvalidOperationException("Cant point DoublyNode to itself");
                }

                previous = value;
            }
        }
    }
}
