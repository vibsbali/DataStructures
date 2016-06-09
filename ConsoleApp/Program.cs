using System;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var list = new DataStructures.ArrayList<int>();

            for (int i = 0; i < 2; i++)
            {
                list.Add(i);
            }


            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }


            list.Insert(1, 2);

            

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
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
