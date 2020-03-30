using System;
using System.Collections.Generic;
using System.Text;

namespace TheSpacePort
{
    public class Menu
    {
        SpacePort _spacePort;
        public Menu (SpacePort spacePort)
        {
            _spacePort = spacePort;
        }

        // Spy: @Group 3, Found the idea with a menuheader and also menu options
        public void MenuHeader()
        {
            Console.Title = "SpacePark";
            Console.ForegroundColor = ConsoleColor.Yellow;
            var header = new[]
            {
            @" ________ _______ _____   ______ _______ _______ _______   _______ _______",
            @"|  |  |  |    ___|     |_|      |       |   |   |    ___| |_     _|       |",
            @"|  |  |  |    ___|       |   ---|   -   |       |    ___|   |   | |   -   |",
            @"|________|_______|_______|______|_______|__|_|__|_______|   |___| |_______|",
            @"",
            @" _______ ______ _______ ______ _______ ______ _______ ______ __  __",
            @"|     __|   __ \   _   |      |    ___|   __ \   _   |   __ \  |/  |",
            @"|__     |    __/       |   ---|    ___|    __/       |      <     <",
            @"|_______|___|  |___|___|______|_______|___|  |___|___|___|__|__|\__|",
        };

            foreach (var line in header)
            {
                Console.WriteLine(line);
            }
        }

        public void MenuOptions()
        {
            
            Console.WriteLine("Options:");
            Console.WriteLine("(1) Check in (2) Check out (3) Quit");

            var optionChoosen = Console.ReadKey().Key;

            switch (optionChoosen)
            {
                case ConsoleKey.D1:
                    _spacePort.CheckIn();
                    break;

                case ConsoleKey.D2:
                    _spacePort.CheckOut();
                    break;

                case ConsoleKey.D3:
                    _spacePort.Quit();
                    break;

                default:
                    break;
            }

        }
        
        
    }
}
