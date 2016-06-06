namespace SortingAlgorithms
{

    static class ExtensionMethod
    {
        public static void Swap<T>(this T[] items, int left, int right)
        {
            if (left != right)
            {
                T temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }
    }
}
