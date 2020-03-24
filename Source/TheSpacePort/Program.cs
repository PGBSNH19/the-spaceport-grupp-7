using System;
using System.Linq;

namespace TheSpacePort
{
    class Program
    {
        static void Main(string[] args)
        {
            var EnvironmentName = Environment.GetEnvironmentVariable("SettingEnvironment");


            Console.WriteLine($"Hello {EnvironmentName} Space!");

            MyContext myContext2 = new MyContext();
            var x = myContext2.parkings.ToList();

            API.GetTraveler();
                
            Console.ReadKey();
        }
    }
}
