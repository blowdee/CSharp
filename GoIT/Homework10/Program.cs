using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework101
{
    delegate void MyDelegate(long a, long b);

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("First operand: ");
            String str1 = Console.ReadLine();
            Console.Write("Second operand: ");
            String str2 = Console.ReadLine();

            long fOper = Convert.ToInt64(str1);
            long sOper = Convert.ToInt64(str2);

            Console.WriteLine("1: +\n2: -\n3: /\n4: *");
            String ops = Console.ReadLine();

            MyDelegate res = new MyDelegate(delegate { });
            for (int i = 0; i < ops.Length; ++i)
            {
                if (ops[i] == '1')
                    res += Operations.Plus;
                else if (ops[i] == '2')
                    res += Operations.Sub;
                else if (ops[i] == '3')
                    res += Operations.Div;
                else if (ops[i] == '4')
                    res += Operations.Sub;
            }
            res.Invoke(fOper, sOper);
        }
    }
}
