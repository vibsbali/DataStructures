using System;
using System.Collections.Generic;
using Core;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNode = new Node {Value = 3 };

            var middleNode = new Node { Value = 5 };
            firstNode.Next = middleNode;

            var lastNode = new Node { Value = 7 };
            middleNode.Next = lastNode;

            Print(firstNode);
        }

        static void Print(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node);
                node = node.Next;
            }
        }
    }
}
