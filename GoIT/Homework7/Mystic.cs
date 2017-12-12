using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team
{
    class Mystic:Base //psycho
    {
        public int killsCount { get; set; } //patients count

        public Mystic()
        {
            Console.Write("Name: ");
            _sName = Console.ReadLine();
            Console.Write("Farm: ");
            farmPerMinute = Convert.ToInt32(Console.ReadLine());
            Console.Write("Exp: ");
            _iExp = Convert.ToInt32(Console.ReadLine());
            Console.Write("Kills: ");
            killsCount = Convert.ToInt32(Console.ReadLine());
            allPlayers.Add(new Mystic(_sName, farmPerMinute, _iExp, killsCount));
        }

        private Mystic(string nameArg, decimal farmArg, int expArg, int killArg)
        {
            _sName = nameArg;
            farmPerMinute = farmArg;
            _iExp = expArg;
            killsCount = killArg;
        }

        public override void GetFarm()
        {
            totalGold = _iExp * farmPerMinute;
            if (killsCount > 0)
                totalGold *= killsCount * 1.2M;
            Console.WriteLine(totalGold);
        }

        public override void ExtraHours(int hoursArg)
        {
            _iExp += hoursArg * 2;
        }
    }
}
