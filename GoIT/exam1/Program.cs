﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam1
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Customer customer = new Customer(shop);
        }
    }
}
