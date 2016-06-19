namespace CoreNew
{
    public class SkipListNode<T>
    {
        public T Value { get; private set; }

        public SkipListNode(T value, int height)
        {
            Value = value;
            Next = new SkipListNode<T>[height];
        }

        //Array of Next Pointers
        public SkipListNode<T>[] Next { get; private set; }
    }
}
