using System;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var myavltree = new AvlTree<int>();

            myavltree.Add(8);
            myavltree.Add(6);
            myavltree.Add(15);
            myavltree.Add(3);
            myavltree.Add(9);
            myavltree.Add(8);
        }

        
    }
}
