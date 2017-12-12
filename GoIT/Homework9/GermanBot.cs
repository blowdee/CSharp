using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class GermanBot:Bot
    {
        private static Dictionary<string, int> german = new Dictionary<string, int>()
        {
            { "hallo", 1 },
        };
        public static new string name = "Bastian";

        public override void SayHello()
        {
            Console.WriteLine("{0}: Hallo!", name);
        }

        public override void HowAreYou()
        {
            Console.WriteLine("{0}: Was ist los?", name);
        }

        public override void SayGoodbye()
        {
            Console.WriteLine("{0}: Wir sehen uns!", name);
        }

        public override void SaySorry()
        {
            Console.WriteLine("{0}: Sorry, ich habe Sie nicht verstanden", name);
        }

        public static bool Indicate(string input)
        {
            foreach (var item in german)
            {
                if (item.Key == input)
                    return true;
            }
            return false;
        }
    }
}
