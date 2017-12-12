using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;
using System.CodeDom;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Format("{0, -7} | {1, -13} | {2, -30} | {3, -9}", "Type", "default value", "min value", "max value"));
            Console.WriteLine("----------------------------------------------------------------------------------------");

            string output = "{0, -7} | {1, -13} | {2, -30} | {3, -9}";
            Console.WriteLine(String.Format(output, "byte", default(byte), byte.MinValue, byte.MaxValue));
            Console.WriteLine(String.Format(output, "sbyte", default(sbyte), sbyte.MinValue, sbyte.MaxValue));
            Console.WriteLine(String.Format(output, "short", default(short), short.MinValue, short.MaxValue));
            Console.WriteLine(String.Format(output, "ushort", default(ushort), ushort.MinValue, ushort.MaxValue));
            Console.WriteLine(String.Format(output, "int", default(int), int.MinValue, int.MaxValue));
            Console.WriteLine(String.Format(output, "uint", default(uint), uint.MinValue, uint.MaxValue));
            Console.WriteLine(String.Format(output, "long", default(long), long.MinValue, long.MaxValue));
            Console.WriteLine(String.Format(output, "ulong", default(ulong), ulong.MinValue, ulong.MaxValue));
            Console.WriteLine(String.Format(output, "float", default(float), float.MinValue, float.MaxValue));
            Console.WriteLine(String.Format(output, "double", default(double), double.MinValue, double.MaxValue));
            Console.WriteLine(String.Format(output, "decimal", default(decimal), decimal.MinValue, decimal.MaxValue));
            Console.WriteLine(String.Format("{0, -7} | {1, -13}", "bool", default(bool)));
            Console.WriteLine(String.Format("{0, -7} | {1, -13}", "char", default(char)));

        }



    }
}
