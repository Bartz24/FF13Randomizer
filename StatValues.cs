using FF13Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{
    public class StatValues
    {
        public int HP { get; set; }
        public int STR { get; set; }
        public int MAG { get; set; }

        public StatValues(int hp, int str, int mag)
        {
            HP = hp;
            STR = str;
            MAG = mag;
        }

        public void Randomize(int total)
        {
            while (HP + STR + MAG < total)
            {
                int val = Math.Max((total - (HP + STR + MAG)) / (total / 20), 1);
                int select = RandomNum.randInt(0, 2);
                if (select == 0)
                    HP += val;
                else if (select == 1)
                    STR += val;
                else
                    MAG += val;
            }
        }
    }
}
