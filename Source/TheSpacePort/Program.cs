using System;
using System.Linq;

namespace TheSpacePort
{
    class Program
    {
        static void Main(string[] args)
        {

        Start:

            Console.WriteLine("Hello to the SpacePort!");
            Console.WriteLine("Please type your name and hit enter");

            string traveller = Console.ReadLine();
            Console.WriteLine($"So you are: {traveller}?");
            Console.WriteLine("(Y) Yes (N) No");
            var yesOrNo = Console.ReadKey().Key;

            API api = new API();
            bool resultOfCheck = false;

            if (yesOrNo == ConsoleKey.Y)
                resultOfCheck = api.IsValidPerson(traveller);

            else
                goto Start;

            if (resultOfCheck == true)
                Console.WriteLine("You were a part of star wars");

            else
                Console.WriteLine("You were not a part of star wars");

            Console.ReadKey();
        }
    }
}
