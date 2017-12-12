using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class GirlScout:Scout
    {

        public static string ShowSports()
        {
            Console.WriteLine("1. Kickboxing");
            Console.WriteLine("2. Pancration");
            int choice;
            while (!Int32.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.Write("Please choose from the list! ");
            }
            switch (choice)
            {
                case 1:
                    return "Kickboxing";
                case 2:
                    return "Pancration";
                default:
                    return null;
            }
        }
    }
}
