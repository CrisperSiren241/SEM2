using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    internal class Class1
    {
        public Class1(string? name, string? description)
        {
            Name = name;
            Description = description;
        }
        public Class1() { }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
