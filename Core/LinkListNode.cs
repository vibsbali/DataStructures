namespace Core
{
    public class LinkListNode<T>
    {
        public LinkListNode<T> Next { get; set; }
        public LinkListNode(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
    }
}
