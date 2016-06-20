using System;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var myavltree = new AvlTree<int>();

            myavltree.Add(4);
            myavltree.Add(2);
            myavltree.Add(7);
            myavltree.Add(6);
            myavltree.Add(8);
            myavltree.Add(5);
            //myavltree.Add(12);

            myavltree.InOrderTraversal(i => Console.WriteLine(i));
        }

        
    }
}
