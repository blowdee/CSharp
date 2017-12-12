using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework14
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemsRepository rep = new ItemsRepository();
            var query = from auto in rep.items
                        where auto.Price <= 1000 && auto.Quantity > 2 && auto.Name.Contains("new")
                        select new { auto.Id, auto.Summ };
            foreach (var item in query)
            {
                Console.WriteLine("{0}. {1}", item.Id, item.Summ);
            }
            GetByWord(rep, "t");
            Pagination(rep);
        }

        static void Pagination(ItemsRepository rep)
        {
            var query = from auto in rep.items
                        select new { auto.Name, auto.Price };
            int len = (query.Count() + 1)/ 2;
            Console.WriteLine("Select page from {0} to {1}", 1, len);
            int input;
            int.TryParse(Console.ReadLine(), out input);
            var ret = query.Skip((input - 1) * 2).Take(2);
            foreach (var item in ret)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Price);
            }

        }

        static void GetByWord(ItemsRepository rep, string keyword)
        {
            var query = from auto in rep.items
                        where auto.Name.Contains(keyword)
                        select new { auto.Name, auto.Price };
            foreach (var item in query)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Price);
            }
        }
    }
}
