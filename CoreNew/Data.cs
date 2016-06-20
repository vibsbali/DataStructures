using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreNew
{
    public class Data : IComparable<Data>
    {
        private readonly DateTime creationDateTime;

        public Data(string message, int priority)
        {
            creationDateTime = new DateTime();
            Message = message;
            Priority = priority;
        }

        public TimeSpan Age

        public string Message { get; private set; }

        public int Priority { get; private set; }

        public int CompareTo(Data other)
        {
            throw new NotImplementedException();
        }
    }
}
