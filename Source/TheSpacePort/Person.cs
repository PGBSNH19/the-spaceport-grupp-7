using System;
using System.Collections.Generic;
using System.Text;

namespace TheSpacePort
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public Starship starship { get; set; }
        public List<string> Starships { get; set; }
        
    }
}
