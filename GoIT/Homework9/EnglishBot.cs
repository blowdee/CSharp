using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class EnglishBot:Bot
    {
        private static Dictionary<string, int> english = new Dictionary<string, int>()
        {
            { "hello", 1 }, { "hi", 1 },
        };
        public static new string name = "John";

        public override void SayHello()
        {
            Console.WriteLine("{0}: Hello, mate", name);
        }

        public override void HowAreYou()
        {
            Console.WriteLine("{0}: Hey, what's up?", name);
        }

        public override void SayGoodbye()
        {
            Console.WriteLine("{0}: Cya", name);
        }

        public override void SaySorry()
        {
            Console.WriteLine("{0}: Lituji, ale já ti nerozumím", name);
        }

        public static bool Indicate(string input)
        {
            foreach (var item in english)
            {
                if (item.Key == input)
                    return true;
            }
            return false;
        }
    }
}
