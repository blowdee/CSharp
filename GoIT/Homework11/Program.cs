using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework11
{
    class Program
    {
        delegate void MyDel(string s);

        static MyDel del = (string output) =>
        {
            string path = @"E:\vsprojects\Homework11\output.txt";
            Console.WriteLine("Where output should be?\n1.File\n2.Console");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(output);
                    sw.Close();
                    Console.WriteLine("Done!");
                }
            }
            else
            {
                Console.WriteLine(output);
            }
        };

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int num;
            if (int.TryParse(input, out num))
            {
                num *= num;
                input = Convert.ToString(num);
            }
            del(input);
        }
    }
}
