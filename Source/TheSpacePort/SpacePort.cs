﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSpacePort
{
    public class SpacePort
    {
        private SpacePortContext _myContext = new SpacePortContext();
        private int _spacePortID { get; set; }
        private int _availableParking { get; set; }
        private List<Parking> _parkings { get; set; }

        public SpacePort()
        {
            var t = CreateParkings(4);
            t.Wait();


        }
        internal void Run()
        {
            Menu menu = new Menu(this);
            
            while (true)
            {
                menu.MenuHeader();
                menu.MenuOptions();
                Console.Clear();
            }
        }

        public void CheckIn()
        {
            Console.WriteLine("Please type your name and hit enter");
            string traveller = Console.ReadLine();

            API api = new API();
            Person person = new Person();
            Starship starship = new Starship();

            person = api.GetPerson(traveller);
            starship = api.GetStarship(person.Starships[0]);
            Console.WriteLine(starship.Name);
            person.Starship = starship;

            _myContext.persons.Add(person);
            var parking = _myContext.parkings.Find(1);
            parking.Starship = person.Starship;
            _myContext.SaveChanges();

            Console.ReadKey();
        }

        public void CheckOut()
        {
            //get the person, 
            //from person get starship
            //from starship get parkingID

            //var parking = _myContext.parkings.Find(1);
            //parking.Starship = null;
            //parking.StarshipID = null;

            var person = _myContext.persons.Where(x => x.Name == "Chewbacca").FirstOrDefault();
            var starship = _myContext.starships.Where(x => x.StarshipID == person.StarshipID).FirstOrDefault();
            var parking = _myContext.parkings.Where(x => x.StarshipID == starship.StarshipID).FirstOrDefault();
            parking.Starship = null;
            parking.StarshipID = null;

            _myContext.SaveChanges();

            _myContext.starships.Remove(starship);
            _myContext.persons.Remove(person);

            _myContext.SaveChanges();
        }

        public static void Quit()
        {
            Environment.Exit(0);
        }

        public async Task CreateParkings(int parkingAmount)
        {
            //var x = _myContext.parkings.Find(2);
            //_myContext.parkings.Remove(new Parking() { ParkingID = 5 });

            //await _myContext.SaveChangesAsync();


            if (_myContext.parkings.Count() < parkingAmount)
            {
                var createNrOfParkings = parkingAmount - _myContext.parkings.Count();

                

                for (int i = 1; i <= createNrOfParkings; i++)
                {
                    Parking parking = new Parking { ParkingSpaceLength = 40, ParkingCost = 100 };

                    _myContext.parkings.Add(parking);
                }

                await _myContext.SaveChangesAsync();
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
