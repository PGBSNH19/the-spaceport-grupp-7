using System;
using System.Collections.Generic;
using System.Text;

namespace TheSpacePort
{
    public class SpacePort
    {
        public int SpacePortID { get; set; }
        public int AvailableParking { get; set; }
        public List<Parking> Parkings { get; set; }


        static void ProcessPayment()
        {

        }

        public void CreateParkings(int parkingAmount)
        {
            for (int i = 1; i <= parkingAmount; i++)
            {
                Parking parking = new Parking { ParkingID = i, ParkingSpaceLength = 40, ParkingCost = 100 };

                if (Parkings == null)
                {
                    Parkings = new List<Parking>();
                    Parkings.Add(parking);
                }
                else
                    Parkings.Add(parking);

            }
        }


        static void ParkStarship()
        {

        }
        static void CheckStarshipLength()
        {

        }
    }
}
