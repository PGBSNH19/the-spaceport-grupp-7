using System;
using System.Collections.Generic;
using System.Text;

namespace TheSpacePort
{
    public class Parking
    {
        public int ParkingID { get; set; }
        public int ParkingCost { get; set; }
        public int ParkingSpaceLength { get; set; }
        public Starship Starship { get; set; }
        public int? StarshipID { get; set; }
    }
}
