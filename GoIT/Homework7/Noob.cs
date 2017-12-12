using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team
{
    sealed class Noob:Base //intern
    {
        Base head;

        public int towersDef { get; set; } //day
        public int matesDef { get; set; } //night

        public int killsCount { get; set; } //patients count

        public int matesHealed { get; set; }

        public Noob(Base player)
        {
            head = player;
            Console.Write("Name: ");
            _sName = Console.ReadLine();
            Console.Write("Farm: ");
            farmPerMinute = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Exp: ");
            _iExp = Convert.ToInt32(Console.ReadLine());

            if(player is Healer)
            {
                Console.Write("Mates healed: ");
                matesHealed = Convert.ToInt32(Console.ReadLine());
                allPlayers.Add(new Noob(_sName, farmPerMinute, _iExp, 1, matesHealed));
            }
            else if(player is Mystic)
            {
                Console.Write("Kills: ");
                killsCount = Convert.ToInt32(Console.ReadLine());
                allPlayers.Add(new Noob(_sName, farmPerMinute, _iExp, 2, killsCount));
            }
            else if(player is Tank)
            {
                Console.Write("Towers: ");
                towersDef = Convert.ToInt32(Console.ReadLine());
                Console.Write("Teammates: ");
                matesDef = Convert.ToInt32(Console.ReadLine());
                allPlayers.Add(new Noob(_sName, farmPerMinute, _iExp, 3, towersDef, matesDef));
            }
        }

        Noob(string nameArg, decimal farmArg, int expArg, params int[] par)
        {
            _sName = nameArg;
            farmPerMinute = farmArg;
            _iExp = expArg;
            if (par[0] == 1)
            {
                matesHealed = par[1];
            }
            else if (par[0] == 2)
            {
                killsCount = par[1];
            }
            else
            {
                towersDef = par[1];
                matesDef = par[2];
            }
        }

        public override void GetFarm()
        {
            if (head is Healer)
            {
                if (matesHealed > 0)
                    totalGold += farmPerMinute * matesHealed;
                totalGold = _iExp * farmPerMinute;
                Console.WriteLine(totalGold);
            }
            else if (head is Mystic)
            {
                totalGold = _iExp * farmPerMinute;
                if (killsCount > 0)
                    totalGold *= killsCount * 1.2M;
                Console.WriteLine(totalGold);
            }
            else if (head is Player)
            {
                totalGold = _iExp * farmPerMinute;
                Console.WriteLine(totalGold);
            }
            else
            {
                totalGold = towersDef * farmPerMinute;
                if (matesDef > 0)
                    totalGold += farmPerMinute * matesDef * 2;
                Console.WriteLine(totalGold);
            }
        }


        public override void ExtraHours(int hoursArg = 0)
        {
            Console.WriteLine("Hey, it's enough for him!");
        }
    }
}
