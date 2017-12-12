using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class BoyScout:Scout
    {

        public static string ShowSports()
        {
            Console.WriteLine("1. Muay Thai");
            Console.WriteLine("2. Box");
            int choice;
            while (!Int32.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.Write("Please choose from the list! ");
            }
            switch (choice)
            {
                case 1:
                    return("Muay Thai");
                case 2:
                    return("Box");
                default:
                    return null;
            }
        }
    }
}
