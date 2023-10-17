using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDB_2
{
    public class Reader
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public Reader(uint id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
