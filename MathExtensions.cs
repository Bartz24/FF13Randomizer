using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{
    public class MathExtensions
    {
        // Sequence must only contain once of each value from [0, n)
        public static int EncodeNaturalSequence(int[] seq)
        {
            int n = seq.Length;
            return Enumerable.Range(0, n).Sum(i => seq[i] * (int)Math.Pow(n, i));
        }
        
        public static int[] DecodeNaturalSequence(int val, int n)
        {
            int[] seq = new int[n];
            for (int i = 0; i < n; i++)
            {
                int mod = val % (int)Math.Pow(n, i + 1);
                seq[i] = mod / (int)Math.Pow(n, i);
                val -= mod;
            }

            return seq;
        }
    }
}
