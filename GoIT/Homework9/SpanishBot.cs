using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class SpanishBot:Bot
    {
        private static Dictionary<string, int> spanish = new Dictionary<string, int>()
        {
            {"¡hola", 1 }, {"hola", 1 },
        };
        public static new string name = "Pedro";

        public override void SayHello()
        {
            Console.WriteLine("{0}: ¡Hola amigo!", name);
        }

        public override void HowAreYou()
        {
            Console.WriteLine("{0}: ¿Qué pasa hombre", name);
        }

        public override void SayGoodbye()
        {
            Console.WriteLine("{0}: ¡Hasta luego!", name);
        }

        public override void SaySorry()
        {
            Console.WriteLine("{0}: Lo siento, no se entendía", name);
        }

        public static bool Indicate(string input)
        {
            foreach (var item in spanish)
            {
                if (item.Key == input)
                    return true;
            }
            return false;
        }
    }
}
