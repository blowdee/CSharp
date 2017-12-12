using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team
{
    abstract class Base
    {
        public static List<Base> allPlayers = new List<Base>();
        public int _iExp { get; set; }
        public decimal farmPerMinute { get; set; }
        public decimal totalGold { get; set; }
        public string _sName { get; set; }

        public abstract void GetFarm();
        public abstract void ExtraHours(int hoursArh);
    }
}
