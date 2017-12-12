using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5, y = 12, z = 2;
            int result = (x++ - --y + --x << z++) * (x + y + z);
            /* we take 5, x = 6, res = 5
             * y -= 1, substract 11, res = -6
             * x -= 1, add 5, res = -1
             * left bit shift on 2 positions, z += 1, res = -4
             * second brackets = 5 + 11 + 3
             * res = -4 * 19 = -76
             */
            Console.WriteLine(result);
        }
    }
}
