using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework14
{
    class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal Summ { get; set; }

        public Item(int idArg, string nameArg, decimal priceArg, int quantityArg, int discountArg)
        {
            Id = idArg;
            Name = nameArg;
            Price = priceArg;
            Quantity = quantityArg;
            Discount = discountArg;
            Summ = quantityArg * priceArg * (discountArg == 0 ? 1 : 100/(100 - discountArg));
        }
    }
}
