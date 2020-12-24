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
            Randomize(Enumerable.Range(0, Vals.Length).Select(i => new Tuple<int, int>(100 - variance, Int32.MaxValue)).ToArray(), variance * Vals.Length);
        }

        public void Randomize(Tuple<int, int>[] bounds, int amount)
        {
            int randTotal = (int)Math.Min(Math.Min(amount, bounds.Select(t => (long)t.Item2).Sum()), Int32.MaxValue);
            while (Vals.Sum() < randTotal)
            {
                int select = SelectNext();
                int val = (int)Math.Max((randTotal - Vals.Sum()) * boundMult(bounds, select), 1);
                Vals[select] += Math.Min(bounds[select].Item2 - bounds[select].Item1 - Vals[select], val);
            }
            for (int i = 0; i < Vals.Length; i++)
            {
                Vals[i] += bounds[i].Item1;
            }
        }

        protected virtual int SelectNext()
        {
            return RandomNum.RandInt(0, Vals.Length - 1);
        }

        private float boundMult(Tuple<int, int>[] bounds, int select)
        {
            return (float)Math.Sqrt(bounds[select].Item2 - bounds[select].Item1) / bounds.Select(t => (float)(t.Item2 - t.Item1)).Sum();
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
