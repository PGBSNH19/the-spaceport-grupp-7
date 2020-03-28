using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheSpacePort
{
    public class SpacePort
    {
        private SpacePortContext _myContext = new SpacePortContext();

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

            var parking = _myContext.parkings.Where(x => x.StarshipID == null).FirstOrDefault();
            if (parking == null)
            {
                Console.WriteLine("Sorry, we are at full capacity. Pleace come back at another time.");
                Thread.Sleep(2000);
                return;
            }
            Console.WriteLine("");
            Console.WriteLine("Please type your name and hit enter");
            
            string traveller = Console.ReadLine();


            if (traveller == "")
            {
                Console.WriteLine("Input was empty, please try again.");
                Thread.Sleep(2000);
                return;
            }
    

            API api = new API();
            Person person = new Person();
            Starship starship = new Starship();

            person = api.GetPerson(traveller);

            if (person == null)
            {
                Console.WriteLine($"You, {traveller}, is not a part of any Star Wars movie.. So unfortunately you can't park here.");
                Console.WriteLine("You will now be sent back to the menu.");
                Thread.Sleep(3000);
                return;
            }
            else if (person.Starships.Count == 0)
            {
                Console.WriteLine($"Excuse me, {traveller}.. It looks like you have no Starship to park...");
                Thread.Sleep(3500);
                Console.WriteLine("How did you even manage to get here??");
                Thread.Sleep(3000);
                Console.WriteLine("You will now be sent back to the menu.");
                Thread.Sleep(3500);
                return;
            }

            starship = api.GetStarship(person.Starships[0]);
            Console.WriteLine($"What a baeutiful {starship.Name}!");
            person.Starship = starship;

            _myContext.persons.Add(person);


            if (parking.ParkingSpaceLength <= starship.Length)
            {
                Console.WriteLine("Sorry, your ship is too big! You can't park here! Hope you find some other parkinglot! Bye!");
                Thread.Sleep(2000);
                Console.Clear();
                return;
            }

            parking.Starship = person.Starship;

            _myContext.SaveChanges();


            Console.WriteLine("You have successfully been checked in to our system! We're glad to have you here!");
            Console.WriteLine("Press any key to get back to the menu.");
            Console.ReadKey();
        }

        public void CheckOut()
        {
            Console.WriteLine("Please type your name and hit enter");
            string traveller = Console.ReadLine();

            var person = _myContext.persons.Include(x => x.Starship).Where(x => x.Name == traveller).FirstOrDefault();

            if (person == null)
            {
                Console.WriteLine(traveller + " is not parked here.");
                Thread.Sleep(2000);
                return;
            }

            var parking = _myContext.parkings.Where(x => x.StarshipID == person.Starship.StarshipID).FirstOrDefault();
            parking.Starship = null;
            parking.StarshipID = null;

            _myContext.starships.Remove(person.Starship);
            _myContext.persons.Remove(person);

            _myContext.SaveChanges();

            Payment(parking);
            Console.WriteLine("You have successfully been checked out and your ship is waiting for you. Hope to see you soon again!");
            Console.WriteLine("Press any key to get back to the menu.");
            Console.ReadKey();
        }
        public void Quit()
        {
            Environment.Exit(0);
        }

        public void Payment(Parking parking)
        {
            var correctParking = _myContext.parkings.Where(x => x.ParkingID == parking.ParkingID).SingleOrDefault();
            Console.WriteLine("Thank you for your payment!");
            Console.WriteLine("");
            Console.WriteLine("Your receipt: ");
            Console.WriteLine($"Total cost for the parking: {correctParking.ParkingCost}");
            Console.WriteLine("");
        }


        public async Task CreateParkings(int parkingAmount)
        {

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
    }
}
