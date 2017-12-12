using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class Program
    {
        static Bot bot;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(65001);
            Console.InputEncoding = Encoding.GetEncoding(10017);
            bot = ChooseBot();
            bot.SayHello();
            bot.HowAreYou();
            Console.ReadLine();
            bot.SayGoodbye();
            Console.ReadLine();
        }

        static Bot ChooseBot(int num = 0)
        {
            string s = default(string);
            if (num == 0)
            {
                Console.WriteLine("Welcome to our chat, please say hello in your language.");
                s = (Console.ReadLine()).ToLower();
            }
            if (num == 1 || UkrainianBot.Indicate(s))
            {
                return new UkrainianBot();
            }
            else if (EnglishBot.Indicate(s) || num == 2)
            {
                return new EnglishBot();
            }
            else if (GermanBot.Indicate(s) || num == 3)
            {
                return new GermanBot();
            }
            else if (SpanishBot.Indicate(s) || num == 4)
            {
                return new SpanishBot();
            }
            else if (CzechBot.Indicate(s) || num == 5)
            {
                return new CzechBot();
            }
            Helper();
            return bot;
        }

        static void Helper()
        {
            Console.WriteLine("What language was that?");
            int cnt = 1;
            foreach(var i in Enum.GetNames(typeof(BotNation)))
            {
                Console.WriteLine("{0}. {1}", cnt++, i);
            }
            int n = 0;
            int.TryParse(Console.ReadLine(), out n);
            if (n > 0 && n < 6)
                ChooseBot(n);
        }
    }
        
    public enum BotNation
    {
        Ukrainian = 1,
        English,
        Czech,
        Spanish,
        German
    }
}
