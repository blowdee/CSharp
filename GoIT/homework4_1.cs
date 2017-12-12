using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace homework4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("The first operand: ");
            int _iFirst = GetTrue();
            while (true)
            {
                char _iOperation = GetOperation();
                Console.Write("The second operand: ");
                int _iSecond = GetTrue();
                _iFirst = Calculate(_iFirst, _iSecond, _iOperation);
            }
        }

        static int GetTrue()
        {
            string _input = Console.ReadLine();
            int _operand;
            while(!int.TryParse(_input, out _operand))
            {
                Console.WriteLine("Please enter a number!");
                _input = Console.ReadLine();
            }
            return _operand;
        }

        static int Add(int firstArg, int secondArg)
        {
            int _iResult;
            _iResult = firstArg + secondArg;
            Console.WriteLine("Result: {0}", _iResult);
            return _iResult;
        }

        static int Substract(int firstArg, int secondArg)
        {
            int _iResult;
            _iResult = firstArg - secondArg;
            Console.WriteLine("Result: {0}", _iResult);
            return _iResult;
        }

        static int Multiply(int firstArg, int secondArg)
        {
            int _iResult;
            _iResult = firstArg * secondArg;
            Console.WriteLine("Result: {0}", _iResult);
            return _iResult;
        }

        static int Divide(int firstArg, int secondArg)
        {
            int _iResult;
            _iResult = firstArg / secondArg;
            Console.WriteLine("Result: {0}", _iResult);
            return _iResult;
        }

        static int Mod(int firstArg, int secondArg)
        {
            int _iResult;
            _iResult = firstArg % secondArg;
            Console.WriteLine("Result: {0}", _iResult);
            return _iResult;
        }

        static int Pow(int firstArg, int secondArg)
        {
            int _iResult;
            _iResult = (int)Math.Pow(firstArg, secondArg);
            Console.WriteLine("Result: {0}", _iResult);
            return _iResult;
        }

        static char GetOperation()
        {
            Console.Write("Operation: ");
            Char operationArg;
            while (true)
            {
                char.TryParse(Console.ReadLine(), out operationArg);
                if (operationArg == '+' || operationArg == '-' ||
                   operationArg == '*' || operationArg == '/' ||
                   operationArg == '%' || operationArg == '^')
                    break;
                else
                {
                    Console.WriteLine("Wrong input, please try another operation.");
                }
            }
            return operationArg;
        }

        static int Calculate(int firstArg, int secondArg, char operationArg)
        {
            switch (operationArg)
            {
                case '+':
                    firstArg = Add(firstArg, secondArg);
                    break;
                case '-':
                    firstArg = Substract(firstArg, secondArg);
                    break;
                case '*':
                    firstArg = Multiply(firstArg, secondArg);
                    break;
                case '/':
                    firstArg = Divide(firstArg, secondArg);
                    break;
                case '%':
                    firstArg = Mod(firstArg, secondArg);
                    break;
                case '^':
                    firstArg = Pow(firstArg, secondArg);
                    break;
                default:
                    Console.WriteLine("It can't be here");
                    break;
            }
            return firstArg;
        }
    }
}
