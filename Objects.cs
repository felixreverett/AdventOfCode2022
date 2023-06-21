using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Objects
    {
        public class Stack
        {
            public string Handle { get; }
            public List<char> Items { get; set; }

            public Stack(string handle)
            {
                Handle = handle;
                this.Items = new();
            }
        }
    }
}
