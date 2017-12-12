using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework12.IteratorPattern;

namespace Homework12
{
    class Program
    {
        static Pupil form = new Pupil();
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("1. Add pupil\n2. Add mark\n3. Get average mark\n4. Show all marks\n5. Exit");
                int input;
                int.TryParse(Console.ReadLine(), out input);

                Console.Clear();
                if (input == 1)
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    int age;
                    Console.Write("Age: ");
                    int.TryParse(Console.ReadLine(), out age);
                    form.AddPupil(name, age);
                }

                else if (input == 2)
                {
                    int mark;
                    string subject;

                    for (int i = 0; i < form.Count; i++)
                    {
                        Console.WriteLine("{0}. {1}", i + 1, form[i]);
                    }

                    Console.Write("Choose a pupil: ");
                    int.TryParse(Console.ReadLine(), out input);

                    Console.Write("Subject: ");
                    subject = Console.ReadLine();

                    Console.Write("Mark: ");
                    int.TryParse(Console.ReadLine(), out mark);
                    Tuple<string, int> temp = new Tuple<string, int>(subject, mark);
                    form[input - 1].Marks?.Add(temp);
                }

                else if (input == 3)
                {
                    for (int i = 0; i < form.Count; i++)
                    {
                        Console.WriteLine("{0}. {1}", i + 1, form[i].Name);
                    }

                    Console.Write("Choose a pupil: ");
                    int.TryParse(Console.ReadLine(), out input);
                    Console.WriteLine(form[input - 1].GetAverage());
                }

                else if (input == 4)
                {
                    for (int i = 0; i < form.Count; i++)
                    {
                        Console.WriteLine("{0}. {1}", i + 1, form[i].Name);
                    }

                    Console.Write("Choose a pupil: ");
                    int.TryParse(Console.ReadLine(), out input);
                    foreach (var mark in form[input - 1].Marks)
                    {
                        Console.WriteLine("{0} mark: {1}", mark.Item1, mark.Item2);
                    }
                    Console.WriteLine();
                }
                else if (input == 5)
                {
                    return;
                }
                else Console.WriteLine("1-5 please\n");
            }
        }
    }
}
