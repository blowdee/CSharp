using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    abstract class Bot
    {
        public static string name { get; set; }

        public abstract void SayHello();
        public abstract void SayGoodbye();
        public abstract void HowAreYou();
        public abstract void SaySorry();
    }
}
