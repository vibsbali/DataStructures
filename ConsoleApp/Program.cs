using System;
using System.Security.Principal;
using ConcreteStructures;
using Core;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Quit to exit");
            var input = "";
            var stack = new DsStack<string>();
            
            while (!(input.ToLower() == "quit"))
            {
                input = Console.ReadLine();
                int rhs = 0;
                int lhs = 0;

                switch (input)
                {
                    case "+":
                        rhs = int.Parse(stack.Pop());
                        lhs = int.Parse(stack.Pop());
                        stack.Push((rhs + lhs).ToString());
                        break;
                    case "-":
                        rhs = int.Parse(stack.Pop());
                        lhs = int.Parse(stack.Pop());
                        stack.Push((rhs + lhs).ToString());
                        break;
                    case "*":
                        rhs = int.Parse(stack.Pop());
                        lhs = int.Parse(stack.Pop());
                        stack.Push((rhs + lhs).ToString());
                        break;
                    case "/":
                        rhs = int.Parse(stack.Pop());
                        lhs = int.Parse(stack.Pop());
                        stack.Push((rhs + lhs).ToString());
                        break;
                    case "%":
                        rhs = int.Parse(stack.Pop());
                        lhs = int.Parse(stack.Pop());
                        stack.Push((rhs + lhs).ToString());
                        break;
                    case "quit":
                        Print(stack);
                        return;
                    default:
                        try
                        {
                            int.Parse(input);
                            stack.Push(input);
                            break;
                        }
                        catch (Exception)
                        {
                            throw new ArgumentException("Unrecognized token : " + input);
                        }
                        
                }
            }}

        static void Print(DsStack<string> stack)
        {
            for (int i = 0; i < stack.Count(); i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
