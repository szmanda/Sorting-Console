using System;
using System.Collections.Generic;
using System.Text;

namespace SortingConsole
{
    public static class ConsoleUI
    {
        public static int Menu()
        {
            int input;
            String inputString;

            Console.WriteLine("===========================================\n| MENU:");
            Console.WriteLine("| 1. Sortuj dane z pliku");
            Console.WriteLine("| 2. Sorowanie przykładowego zestawu");
            Console.WriteLine("| 3. Test wydajności algorytmow sortowania");

            inputString = Console.ReadLine();

            try
            {
                input = Int32.Parse(inputString);
                if (input < 5) Console.WriteLine($"Wybrano opcję {input}");
                else
                {
                    Console.WriteLine($"Niepoprawny argument");
                    input = Menu();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine($"Niepoprawny argument");
                input = Menu();
            }

            return input;
        }
    }
}
