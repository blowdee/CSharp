using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class UkrainianBot:Bot
    {
        private static Dictionary<string, int> ukrainian = new Dictionary<string, int>()
        { { "привіт", 1 }, { "здоров", 1 }, { "вітаю", 1 },
            { "бувай", 2 }, { "до побачення", 2 }
        };

        public static new string name = "Андрій";

        public override void SayHello()
        {
            Console.WriteLine("{0}: Привіт, чуваче!", name);
        }

        public override void HowAreYou()
        {
            Console.WriteLine("{0}: Як ся маєш?", name);
        }

        public override void SayGoodbye()
        {
            Console.WriteLine("{0}: Бувай", name);
        }

        public override void SaySorry()
        {
            Console.WriteLine("{0}: Вибач, я тебе не зрозумів", name);   
        }

        public static bool Indicate(string input)
        {
            foreach (var item in ukrainian)
            {
                if (item.Key == input)
                    return true;
            }
            return false;
        }
    }
}
