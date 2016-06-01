namespace Core
{
    public class SinglyLinkedListNode<T>
    {
        public SinglyLinkedListNode<T> Next { get; set; } = null;
        public T Value { get; private set; }

        public SinglyLinkedListNode(T value)
        {
            Value = value;
        }
    }
}
