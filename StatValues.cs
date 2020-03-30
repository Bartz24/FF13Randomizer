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
        public int[] Vals { get; set; }

        public StatValues(int count)
        {
            Vals = new int[count];
        }

        public void Randomize(int variance)
        {
            int randTotal = variance * Vals.Length;
            while (Vals.Sum() < randTotal)
            {
                int val = (int)Math.Max((randTotal - Vals.Sum()) / (randTotal / 20f), 1);
                int select = RandomNum.RandInt(0, Vals.Length-1);
                Vals[select] += val;
            }
            for (int i = 0; i < Vals.Length; i++)
            {
                Vals[i] += 100 - variance;
            }
        }

        public int this[int i]
        {
            get
            {
                return Vals[i];
            }
            set
            {
                Vals[i] = value;
            }
        }
    }
}
