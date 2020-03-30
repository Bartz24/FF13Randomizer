using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    class RandomNum
    {
        private static Random rand = null;

        public static void SetRand(Random random)
        {
            if (rand != null)
                throw new NullReferenceException("Random has not been cleared yet!");
            rand = random;
        }

        public static void ClearRand()
        {
            rand = null;
        }

        /// <summary>
        /// Gets a random number from (low, high)
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static int RandInt(int low, int high)
        {
            CheckRand();
            return rand.Next(low, high + 1);
        }

        private static void CheckRand()
        {
            if (rand == null)
                throw new NullReferenceException("Random has not been set!");
        }

        public static int RandSeed()
        {
            SetRand(new Random());
            int val = RandInt((int)1e8, (int)1e9 - 1);
            ClearRand();
            return val;
        }

        public static int RandIntNorm(double center, double std, int low, int high)
        {
            CheckRand();
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double randNormal = center + std * randStdNormal;
            return Math.Min(high, Math.Max(low, (int)Math.Round(randNormal)));
        }

        public static T SelectRandomWeighted<T>(List<T> list, Func<T, int> weightFunc)
        {
            CheckRand();
            List<T> weightedList = list.Where(t => weightFunc.Invoke(t) > 0).ToList();
            if (weightedList.Count == 0)
                return default(T);
            int totalWeight = weightedList.Sum(t => weightFunc.Invoke(t));
            if (totalWeight == 0)
                throw new Exception("Total weight cannot be 0");
            int i = 0;
            int index = RandInt(0, totalWeight - 1);
            while(index >= weightFunc.Invoke(weightedList[i]))
            {               
                index -= weightFunc.Invoke(weightedList[i]);
                i++;
            }
            return weightedList[i];
        }
    }
}
