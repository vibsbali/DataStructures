using System;
using System.Collections;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var list = new ArrayList();
            list.RemoveAt(0);
        }

        static void Print<T>(T[] stack)
        {
            for (int i = 0; i < stack.Length; i++)
            {
                Console.WriteLine(stack[i]);
            }
        }
    }
}
