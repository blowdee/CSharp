using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    class Pupil
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Tuple<string, int>> Marks { get; set; }
        
        public Pupil(string nameArg, int ageArg)
        {
            Marks = new List<Tuple<string, int>>();
            Name = nameArg;
            Age = ageArg;
        }

        public double? GetAverage() //Don't c any sense to use yield here
        {
            if(Marks.Count == 0)
            {
                Console.WriteLine("No marks yet");
                return null;
            }
            double sum = 0;
            foreach (var mark in Marks)
            {
                sum += mark.Item2;
            }
            return sum / Marks.Count;
        }
    }
}
