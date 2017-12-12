using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class CzechBot:Bot
    {
        private static Dictionary<string, int> czech = new Dictionary<string, int>()
        {
            { "ahoj", 1 }, { "halo", 1 },
        };
        public static new string name = "Jindřich";

        public override void SayHello()
        {
            Console.WriteLine("{0}: Ahoj kamaráde!", name);
        }

        public override void HowAreYou()
        {
            Console.WriteLine("{0}: Jak se máš?", name);
        }

        public override void SayGoodbye()
        {
            Console.WriteLine("{0}: Uvidíme se!", name);
        }

        public override void SaySorry()
        {
            Console.WriteLine("{0}: Lituji, ale já ti nerozumím", name);
        }

        public static bool Indicate(string input)
        {
            foreach (var item in czech)
            {
                if (item.Key == input)
                    return true;
            }
            return false;
        }
    }
}
