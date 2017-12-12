using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class Program
    {
        static void Ratings()
        {
            while (true)
            {
                Console.WriteLine("\nWhat do you want to check?");
                Console.WriteLine("1. Camp average mark");
                Console.WriteLine("2. Best scout's mark");
                Console.WriteLine("3. The most successful");
                Console.WriteLine("4. The most active");
                Console.WriteLine("5. The lamest one");
                Console.WriteLine("6. I'm done.");
                int choice;
                while (!Int32.TryParse(Console.ReadLine(), out choice)) { }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Average camp mark: {0}", Scout.GetAverageForCamp());
                        break;
                    case 2:
                        Console.WriteLine("Boys: {0} Girls: {1}", Scout.GetBestScout(1), Scout.GetBestScout(2));
                        break;
                    case 3:
                        Console.WriteLine("Boys: {0} Girls: {1}", Scout.GetSuccessScout(1), Scout.GetBestScout(2));
                        break;
                    case 4:
                        Console.WriteLine("Boys: {0} Girls: {1}", Scout.GetActiveScout(1), Scout.GetBestScout(2));
                        break;
                    case 5:
                        Console.WriteLine("Boys: {0} Girls: {1}", Scout.GetLoser(1), Scout.GetBestScout(2));
                        break;
                    case 6:
                        return;
                }
            }
            }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\nList of possible actions:");
                Console.WriteLine("1. Add new member");
                Console.WriteLine("2. Send in sports");
                Console.WriteLine("3. Remove one sport");
                Console.WriteLine("4. Award scout");
                Console.WriteLine("5. Show all members");
                Console.WriteLine("6. Ratings");
                Console.WriteLine("7. Exit menu\n");
                int choice;
                while (!Int32.TryParse(Console.ReadLine(), out choice)) { }
                switch (choice)
                {
                    case 1:
                        Scout.AddScout();
                        break;
                    case 2:
                        Scout.AddSport();
                        break;
                    case 3:
                        Scout.RemoveSport();
                        break;
                    case 4:
                        Scout.AwardScout();
                        break;
                    case 5:
                        Scout.GetList();
                        break;
                    case 6:
                        Ratings();
                        break;
                    case 7:
                        return;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our camp!");
            Menu();
        }
    }
}
