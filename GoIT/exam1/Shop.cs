using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam1
{
    class Shop
    {
        public static String[] _productNames { get; private set; }
        public static decimal[] _prices { get; private set; }

        static Shop()
        {
            _productNames = new String[5] { "Protein", "BCAA", "Gainer", "Steroids", "Banana"};
            _prices = new decimal[5] {18.20M, 16.70M, 12.40M, 31.98M, 2.18M};
        }

        public static void Show()
        {
            Console.WriteLine("----------Products----------");
            int i;
            for (i = 0; i < _productNames.Length; ++i)
            {
                Console.WriteLine("{0}. {1, -10} : $ {2}", i + 1, _productNames[i], _prices[i]);
            }
            Console.WriteLine("\n{0}. Exit", i + 1);
            Console.WriteLine("----------------------------");
        }
    }
}
