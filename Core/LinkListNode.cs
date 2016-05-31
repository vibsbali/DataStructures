namespace Core
{
    public class LinkListNode<T>
    {
        public LinkListNode<T> Next { get; set; } = null;
        public T Value { get; private set; }

        public LinkListNode(T value)
        {
            Value = value;
        }
    }
}
