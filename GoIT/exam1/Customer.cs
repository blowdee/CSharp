using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam1
{
    class Customer
    {
        public String _name { get; set; }
        public String[] _order { get; set; }
        public int[] _quantity { get; set; }

        public Customer(Shop shop)
        {
            Console.Write("Hello, what's your name? ");
            _name = Console.ReadLine();
            while(_name == "")
            {
                _name = Console.ReadLine();
            }
            Console.WriteLine("{0}, what are you looking for?", _name);
            Shop.Show();
            MakeOrder();
        }

        public void MakeOrder()
        {
            int _productsCount = Shop._productNames.Length + 1;
            _quantity = new int[_productsCount - 1];
            int _pos, _num;
            String _input;
            while(true)
            {
                Console.Write("\nPoint: ");
                _input = Console.ReadLine();
                int.TryParse(_input, out _pos);
                if (_pos == _productsCount)
                {
                    ShowOrder();
                    break;
                }
                Console.Write("Count: ");
                _input = Console.ReadLine();
                int.TryParse(_input, out _num);
                _quantity[_pos - 1] += _num;
            }
        }

        public void ShowOrder()
        {
            bool _orderEmpty = true;
            for (int i = 0; i < _quantity.Length; ++i)
            {
                if (_quantity[i] > 0)
                {
                    _orderEmpty = false;
                    break;
                }
            }
            if (!_orderEmpty)
            {
                decimal _discount;
                decimal _summ = 0M;
                Console.Write("Your discount (0 if you don't have): ");
                _discount = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("\n----------Check----------");
                for (int i = 0; i < _quantity.Length; ++i)
                {
                    if (_quantity[i] > 0)
                    {
                        decimal _forOne = _quantity[i] * Shop._prices[i];
                        Console.WriteLine("{0, -10} x {1, 2} = $ {2}",
                            Shop._productNames[i], _quantity[i], _forOne);
                        _summ += _forOne;
                    }
                }
                _discount /= 100; 
                Console.WriteLine("\n{0, -10} $ {1, -10}", "Total", _summ - _summ * _discount);
                Console.WriteLine("{0, -10} $ {1, -10}", "Discount: ", _summ * _discount);
                Console.WriteLine("------------------------");
            }
            else
            {
                Console.WriteLine("Seems like you didn't order anything. Have a good day!");
            }
        }
    }
}
