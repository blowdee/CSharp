using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team
{
    class Program
    {
        static void Main(string[] args)
        {
             Menu();
        }

        static void ShowStats(Base player)
        {
            Console.Write("{0} farmed ", player._sName);
            (player as Player)?.GetFarm();
            (player as Tank)?.GetFarm();
            (player as Mystic)?.GetFarm();
            (player as Healer)?.GetFarm();
            (player as Noob)?.GetFarm();
        }

        static void AddPlayer()
        {
            Console.WriteLine("Who has joined our team?");
            Console.WriteLine("1.Healer\n2.Mystic\n3.Just a player\n4.Tank\n5.Noob...again\n");
            string input = Console.ReadLine();
            int choice;
            Int32.TryParse(input, out choice);
            switch(choice)
            {
                case 1:
                    new Healer();
                    break;
                case 2:
                    new Mystic();
                    break;
                case 3:
                    new Player();
                    break;
                case 4:
                    new Tank();
                    break;
                case 5:
                    Base temp = ChooseHead();
                    if(temp != null)
                    new Noob(temp);
                    break;
                default:
                    Console.WriteLine("Oops!");
                    break;
            }
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("1. Add player\n2. Show stats\n3. Add extra hours\n4. Exit");
                string input = Console.ReadLine();
                int choice;
                Int32.TryParse(input, out choice);
                Console.Clear();
                if (choice == 1)
                {
                    AddPlayer();
                }
                else if (choice == 2)
                {
                    if(Base.allPlayers.Count > 0)
                    ShowStats(ShowAll());
                    else
                        Console.WriteLine("Nobody is here");
                }
                else if (choice == 3)
                {
                    if (Base.allPlayers.Count > 0)
                    {
                        Base one = ShowAll();
                        Console.Write("Hours: ");
                        int hours = Convert.ToInt32(Console.ReadLine());
                        one.ExtraHours(hours);
                    }
                    else
                        Console.WriteLine("Nobody is here");
                }
                else if (choice == 4)
                {
                    return;
                }
                else Console.WriteLine("Oops");
            }
        }

        static Base ShowAll()
        {
            int i = 0;
            foreach (var p in Base.allPlayers)
            {
                i++;
                Console.WriteLine("{0}. {1} {2, -15}", i, p._sName, p.ToString());
            }
            Console.Write("Choose: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (i > 0)
                return Base.allPlayers[choice - 1];
            else return null;
        }

        static Base ChooseHead()
        {
            if (Base.allPlayers.Count == 0)
            {
                Console.WriteLine("There are no members of the team!");
                return null;
            }
            Console.WriteLine("Choose a mentor for our newbie");
            return ShowAll();
        }
    }
}
