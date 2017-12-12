using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace homework2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            String num = "1234567890";
            foreach (char c in num)
            {
                int cur = (int)c - 48;
                if (cur % 2 == 1)
                {
                    if (cur != 9)
                        Console.Write(cur + 1);
                    else Console.Write(0);
                }
                else
                    Console.Write(cur);
            }
        }
    }
}
