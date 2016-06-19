using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using DataStructures;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var names = new[] { "Vaibhav", "Vasudha", "Sheebu", "Mama", "Vaibhav"};

            foreach (var name in names)
            {
                Console.WriteLine(name.GetHashCode());
            }

        }
    }
}
