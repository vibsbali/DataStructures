﻿namespace Core
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
