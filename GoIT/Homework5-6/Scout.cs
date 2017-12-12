using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class Scout
    {
        static List<Scout> scouts = new List<Scout>();
        public string name { get; set; }
        public List<int> marks = new List<int>();
        public string sports { get; set; }
        public int gender { get; set; }

        static Scout()
        {
            scouts.Add(new Scout("Raiden", 1));
            scouts.Add(new Scout("Scorpion", 1));
            scouts.Add(new Scout("Sonya", 2));
            scouts.Add(new Scout("Johny", 1));
            scouts.Add(new Scout("Kitana", 2));
            scouts.Add(new Scout("Reptile", 1));
        }

        public Scout()
        {

        }

        Scout(string nameArg, int genderArg)
        {
            if (genderArg == 1)
                new BoyScout();
            else new GirlScout();
            name = nameArg;
            gender = genderArg;
        }

        public static void AddScout()
        {
            Console.Write("Scout's name: ");
            string _input = Console.ReadLine();
            Console.Write("Scout's gender (1-male, 2-female): ");
            int _gender;
            while (true)
            {
                Int32.TryParse(Console.ReadLine(), out _gender);
                if (_gender == 1 || _gender == 2)
                    break;
                else
                    Console.Write("Please enter 1 or 2: ");
            }
            scouts.Add(new Scout(_input, _gender));
        }

        public static void AddSport()
        {
            Console.WriteLine("Choose one from the list");
            GetList();
            Console.Write("What scout should go?: ");
            int num;
            Int32.TryParse(Console.ReadLine(), out num);
            num--;
            if(scouts[num].sports != null)
            {
                Console.WriteLine("Scout already has sport");
                return;
            }
            if (scouts[num].gender == 1)
                scouts[num].sports = BoyScout.ShowSports();
            else
                scouts[num].sports = GirlScout.ShowSports();
        }

        public static void RemoveSport()
        {
            int num;
            GetSportList();
            Console.WriteLine("\nWho should stop exercise?: ");
            Int32.TryParse(Console.ReadLine(), out num);
            num--;
            scouts[num].sports = null;
            //if (scouts[num].Item2 == 1)
            //    BoyScout;
            //else GirlScout;
        }

        public static void AwardScout()
        {
            int num;
            Console.WriteLine("Who should be awarded?: ");
            GetList();
            Int32.TryParse(Console.ReadLine(), out num);
            num--;
            string text;
            int points;
            Console.Write("Award for: ");
            text = Console.ReadLine();
            Console.Write("\nPoints: ");
            Int32.TryParse(Console.ReadLine(), out points);
            Console.WriteLine("Scout {0} is awarded for {1} with {2} points", scouts[num].name, text, points);
            scouts[num].marks.Add(points);
        }

        public static void GetList()
        {
            Console.WriteLine("{0, -2} {1, -15} {2}", "#", "Name", "Gender");
            for(int i = 0; i < scouts.Count; ++i)
            {
                string genderArg;
                if (scouts[i].gender== 1)
                    genderArg = "Boy";
                else
                    genderArg = "Girl";
                Console.WriteLine("{0}. {1, -15} {2}", i+1, scouts[i].name, genderArg);
            }
        }

        public static void GetSportList()
        {
            Console.WriteLine("{0, -2} {1, -15} {2, -5} {3}", "#", "Name", "Gender", "Sport");
            for (int i = 0; i < scouts.Count; ++i)
            {
                string genderArg;
                if (scouts[i].gender == 1)
                    genderArg = "Boy";
                else
                    genderArg = "Girl";
                Console.WriteLine("{0}. {1, -15} {2, -5} {3}", 
                    i + 1, scouts[i].name, genderArg, scouts[i].sports == null ? "Empty" : scouts[i].sports);
            }
        }

        public static double GetAverageForScout(int num)
        {
            double total = 0;
            num--;
            for(int i = 0; i < scouts[num].marks.Count; ++i)
            {
                total += scouts[num].marks[i];
            }
            return total / scouts[num].marks.Count;
        }

        public static double GetAverageForCamp()
        {
            double total = 0;
            int count = 0;
            for(int i = 0; i < scouts.Count; ++i)
            {
                count += scouts[i].marks.Count;
                if(scouts[i].marks.Count == 0)
                    continue;
                double cnt = 0;
                for (int j = 0; j < scouts[i].marks.Count; ++j)
                    cnt += scouts[i].marks[j];
                total += cnt/scouts[i].marks.Count;
            }
            return total/count;
        }

        public static string GetBestScout(int male)
        {
            double total = 0;
            int best = -1;
            for (int i = 0; i < scouts.Count; ++i)
            {
                if (scouts[i].marks.Count == 0 || scouts[i].gender != male)
                    continue;
                double cnt = 0;
                for (int j = 0; j < scouts[i].marks.Count; ++j)
                    cnt += scouts[i].marks[j];
                cnt /= scouts[i].marks.Count;
                if (cnt > total)
                {
                    best = i;
                    total = cnt;
                }
            }
            if (best == -1)
                return "-";
            return scouts[best].name;
        }

        public static string GetSuccessScout(int male)
        {
            long total = 0;
            int best = -1;
            for (int i = 0; i < scouts.Count; ++i)
            {
                if (scouts[i].gender != male)
                    continue;
                long cnt = 0;
                for (int j = 0; j < scouts[i].marks.Count; ++j)
                    cnt += scouts[i].marks[j];
                if (cnt > total)
                {
                    best = i;
                    total = cnt;
                }
            }
            if (best == -1)
                return "-";
            return scouts[best].name;
        }

        public static string GetActiveScout(int male)
        {
            int best = -1;
            long cnt = 0;
            for(int i = 0; i < scouts.Count; ++i)
            {
                if (scouts[i].gender != male)
                    continue;
                if (scouts[i].marks.Count > cnt)
                {
                    cnt = scouts[i].marks.Count;
                    best = i;
                }
            }
            if (best == -1)
                return "-";
            return scouts[best].name;
        } 

        public static string GetLoser(int male)
        {
            long total = long.MaxValue;
            int best = -1;
            for (int i = 0; i < scouts.Count; ++i)
            {
                if (scouts[i].gender != male)
                    continue;
                if ((scouts[i].marks.Count <= total)) //to show last from most passive
                {
                    total = scouts[i].marks.Count;
                    best = i;
                }
            }
            if (best == -1)
                return "-";
            return scouts[best].name;
        }

    }
}
