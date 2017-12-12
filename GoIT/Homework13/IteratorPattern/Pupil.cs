using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;

namespace Homework12.IteratorPattern
{
    class Pupil : Aggregate
    {
        private static List<Pupil> pupils = new List<Pupil>()
        {
            new Pupil ("Abby", 13),
            new Pupil ("John", 14),
            new Pupil ("Nate", 13),
            new Pupil ("Dane", 14),
        };

        public string Name { get; set; }
        public int Age { get; set; }
        public List<List<Tuple<string, int>>> Marks = new List<List<Tuple<string, int>>>();

        public Pupil(string nameArg, int ageArg)
        {
            Marks.Add(new List<Tuple<string, int>>());
            Name = nameArg;
            Age = ageArg;
        }

        public double? GetAverage() //Don't c any sense to use yield here
        {
            if (Marks.Count == 0)
            {
                Console.WriteLine("No marks yet");
                return null;
            }
            double sum = 0;
            Iterator i = pupils.CreateIterator();

            object item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }
            return sum / Marks.Count;
        }

        public override Iterator CreateIterator()
        {
            return new PupilIterator(this);
        }

        public void AddPupil(string nameArg, int ageArg)
        {
            pupils.Add(new Pupil(nameArg, ageArg));
        }

        public int Count
        {
            get { return pupils.Count; }
        }

        public object this[int index]
        {
            get { return pupils[index]; }
        }

    }
}
