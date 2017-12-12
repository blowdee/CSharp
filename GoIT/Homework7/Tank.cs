using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team
{
    class Tank:Base //security
    {
        public int towersDef { get; set; } //day
        public int matesDef { get; set; } //night

        public Tank()
        {
            Console.Write("Name: ");
            _sName = Console.ReadLine();
            Console.Write("Farm: ");
            farmPerMinute = Convert.ToInt32(Console.ReadLine());
            Console.Write("Exp: ");
            _iExp = Convert.ToInt32(Console.ReadLine());
            Console.Write("Towers: ");
            towersDef = Convert.ToInt32(Console.ReadLine());
            Console.Write("Teammates: ");
            matesDef = Convert.ToInt32(Console.ReadLine());
            allPlayers.Add(new Tank(_sName, farmPerMinute, _iExp, towersDef, matesDef));
        }

        private Tank(string nameArg, decimal farmArg, int expArg, int towerArg, int mateArg)
        {
            _sName = nameArg;
            farmPerMinute = farmArg;
            _iExp = expArg;
            towersDef = towerArg;
            matesDef = mateArg;
        }

        public override void GetFarm()
        {
            totalGold = towersDef * farmPerMinute;
            if (matesDef > 0)
                totalGold += farmPerMinute * matesDef * 2;
            Console.WriteLine(totalGold);
        }

        public override void ExtraHours(int hoursArg)
        {
            _iExp += hoursArg * 3;
        }
    }
}
