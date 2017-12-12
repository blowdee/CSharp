using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework101
{
    class Operations
    {
        public static void Plus(long firstArg, long secondArg)
        {
            Console.WriteLine("Result: {0}", firstArg + secondArg);
        }

        public static void Sub(long firstArg, long secondArg)
        {
            Console.WriteLine("Result: {0}", firstArg - secondArg);
        }

        public static void Multi(long firstArg, long secondArg)
        {
            Console.WriteLine("Result: {0}", + firstArg * secondArg);
        }

        public static void Div(long firstArg, long secondArg)
        {
            Console.WriteLine("Result: {0}", + firstArg / secondArg);
        }
    }
}
