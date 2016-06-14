using System;
using System.Collections.Generic;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var myTree = new Tree<int>();

            myTree.Add(1);
            myTree.Add(2);
            myTree.Add(3);
            myTree.Add(10);
            myTree.Add(8);
            myTree.Add(7);

            Console.WriteLine(myTree.Contains(4));
            Console.WriteLine(myTree.Contains(7));

            Console.WriteLine(myTree.Remove(4));
            Console.WriteLine(myTree.Remove(7));
        }
    }
}
