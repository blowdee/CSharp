using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework14
{
    class ItemsRepository
    {
        public List<Item> items;
        public ItemsRepository()
        {
            items = new List<Item>()
            {
                new Item(1, "Golf new", 900, 6, 30),
                new Item(2, "Passat", 1030, 4, 0),
                new Item(3, "Polo", 780, 4, 5),
                new Item(4, "Jetta", 1100, 2, 0),
                new Item(5, "Touareg", 1800, 5, 10),
                new Item(6, "Tiguan", 940, 3, 0),
                new Item(7, "Touran new", 1470, 1, 0),
            };
        }
        
    }
}
