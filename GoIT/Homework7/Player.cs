using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team
{
    class Player:Base
    {

        public Player()
        {
            Console.Write("Name: ");
            _sName = Console.ReadLine();
            Console.Write("Farm: ");
            farmPerMinute = Convert.ToInt32(Console.ReadLine());
            Console.Write("Exp: ");
            _iExp = Convert.ToInt32(Console.ReadLine());
            allPlayers.Add(new Player(_sName, farmPerMinute, _iExp));
        }

        private Player(string nameArg, decimal farmArg, int expArg)
        {
            _sName = nameArg;
            farmPerMinute = farmArg;
            _iExp = expArg;
        }

        public override void GetFarm()
        {
            totalGold = _iExp * farmPerMinute;
            Console.WriteLine(totalGold);
        }

        public override void ExtraHours(int hoursArg)
        {
            _iExp += hoursArg * 4;
        }
    }
}
