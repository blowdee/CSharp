using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team
{
    class Healer:Base
    {
        public int matesHealed { get; set; }

        public Healer()
        {
            Console.Write("Name: ");
            _sName = Console.ReadLine();
            Console.Write("Farm: ");
            farmPerMinute = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Exp: ");
            _iExp = Convert.ToInt32(Console.ReadLine());
            Console.Write("Mates healed: ");
            matesHealed = Convert.ToInt32(Console.ReadLine());
            allPlayers.Add(new Healer(_sName, farmPerMinute, _iExp, matesHealed));
        }

        private Healer(string nameArg, decimal farmArg, int expArg, int healArg)
        {
            _sName = nameArg;
            farmPerMinute = farmArg;
            _iExp = expArg;
            matesHealed = healArg;
        }

        public override void GetFarm()
        {
            totalGold = _iExp * farmPerMinute;
            if (matesHealed > 0)
                totalGold += farmPerMinute * matesHealed;
            Console.WriteLine(totalGold);
        }

        public override void ExtraHours(int hoursArg)
        {
            _iExp += hoursArg;
        }
    }
}
