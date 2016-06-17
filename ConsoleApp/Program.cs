using System;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var mySkipList = new SkipList<int>();

            mySkipList.Add(4);
            mySkipList.Add(1);
            mySkipList.Add(5);
            mySkipList.Add(3);
            mySkipList.Add(2);


            foreach (var i in mySkipList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(mySkipList.Contains(0));

            mySkipList.Remove(4);

            foreach (var i in mySkipList)
            {
                Console.WriteLine(i);
            }

        }

        
    }
}
