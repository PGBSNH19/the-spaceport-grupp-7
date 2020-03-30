using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheSpacePort
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public Starship Starship { get; set; }
        public int StarshipID { get; set; }

        [NotMapped]
        public List<string> Starships { get; set; }
        
    }
}
