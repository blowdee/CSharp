using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //correct input expected (results should be < 2*10e9)
            int _iCircleRad;
            Console.WriteLine("Circle:");
            Console.Write("Radius = ");
            _iCircleRad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("S = {0}", _iCircleRad * _iCircleRad * Math.PI);

            int _iSphereRad;
            Console.WriteLine("\nSphere:");
            Console.Write("Radius = ");
            _iSphereRad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("V = {0}", _iSphereRad * _iSphereRad * _iSphereRad * Math.PI * 4 / 3);

            int _iSide1;
            int _iSide2;
            Console.WriteLine("\nRectangle:");
            Console.Write("Length = ");
            _iSide1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Width = ");
            _iSide2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("S = {0}", _iSide1 * _iSide2);

            int _iSide3;
            Console.WriteLine("\nCuboid:");
            Console.Write("Length = ");
            _iSide1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Width = ");
            _iSide2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Height = ");
            _iSide3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("V = {0}", _iSide1 * _iSide2 * _iSide3);
        }
    }
}
