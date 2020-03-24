using System;
using System.Collections.Generic;

namespace TheSpacePort
{
    internal class SwapiResponse
    {

        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public IEnumerable<Person> Results { get; set; }
    }
}