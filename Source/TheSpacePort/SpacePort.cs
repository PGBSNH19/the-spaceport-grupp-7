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

            var parking = _myContext.parkings.Where(x => x.StarshipID == null).FirstOrDefault();
            if (parking == null)
            {
                Console.WriteLine("Sorry, we are full. Pleace come back at another time.");
                Thread.Sleep(2000);
                return;
            }

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
                Console.WriteLine(traveller + " is not a part of any Star Wars movie.");
                Thread.Sleep(2000);
                return;
            }

            starship = api.GetStarship(person.Starships[0]);
            Console.WriteLine(starship.Name);
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

            //kanske try catch på egentligen alla savechanges?
            _myContext.SaveChanges();


            Console.WriteLine("You have successfully checked in! We're glad to have you here!");
            Console.WriteLine("Press any key to get back to the menu.");
            Console.ReadKey();
        }

        public void CheckOut()
        {
            Console.WriteLine("Please type your name and hit enter");
            string traveller = Console.ReadLine();
            //get the person, 
            //from person get starship
            //from starship get parkingID

            var person = _myContext.persons.Where(x => x.Name == traveller).FirstOrDefault();

            if (person == null)
            {
                Console.WriteLine(traveller + " is not parked here.");
                Thread.Sleep(2000);
                return;
            }

            var starship = _myContext.starships.Where(x => x.StarshipID == person.StarshipID).FirstOrDefault();
            var parking = _myContext.parkings.Where(x => x.StarshipID == starship.StarshipID).FirstOrDefault();
            parking.Starship = null;
            parking.StarshipID = null;


            try
            {
            _myContext.SaveChanges();

            }
            catch (Exception)
            {

                throw new Exception();
            }

            _myContext.starships.Remove(starship);
            _myContext.persons.Remove(person);

            _myContext.SaveChanges();

            //payment metod som kollar pris från databas 
            Payment(parking);
            Console.WriteLine("You have successfully checked out: " + starship.Name + ". Hope to see you soon, again!");
            
            Console.WriteLine("Press any key to get back to the menu.");
            Console.ReadKey();
        }

        public void Payment(Parking parking)
        {
            var correctParking = _myContext.parkings.Where(x => x.ParkingID == parking.ParkingID).SingleOrDefault();

            Console.WriteLine("This is your receipt: ");
            Console.WriteLine("You have now paid " + correctParking.ParkingCost);
        }

        public static void Quit()
        {
            Environment.Exit(0);
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
