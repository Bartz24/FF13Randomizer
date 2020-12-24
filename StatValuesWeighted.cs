using FF13Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{
    public class StatValuesWeighted : StatValues
    {
        private int[] weights;
        public StatValuesWeighted(int[] weights) : base(weights.Length)
        {
            this.weights = weights;
        }

        protected override int SelectNext()
        {
            return RandomNum.SelectRandomWeighted(Enumerable.Range(0, weights.Length).ToList(), i => weights[i]);
        }
    }
}
