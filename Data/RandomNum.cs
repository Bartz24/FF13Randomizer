using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    class RandomNum
    {
        public static Random rand = new Random();

        /// <summary>
        /// Gets a random number from (low, high)
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static int randInt(int low, int high)
        {
            
            return rand.Next(low, high + 1);
        }

        public static void SetSeed(int seed)
        {
            rand = new Random(seed);
        }

        public static int randSeed()
        {
            return randInt((int)1e8, (int)1e9 - 1);
        }

        public static int randIntNorm(double center, double std, int low, int high)
        {
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double randNormal = center + std * randStdNormal;
            return Math.Min(high, Math.Max(low, (int)Math.Round(randNormal)));
        }

        public static T SelectRandomWeighted<T>(List<T> list, Func<T, int> weightFunc)
        {
            List<T> weightedList = list.Where(t => weightFunc.Invoke(t) > 0).ToList();
            int totalWeight = weightedList.Sum(t => weightFunc.Invoke(t));
            if (totalWeight == 0)
                throw new Exception("Total weight cannot be 0");
            int i = 0;
            int index = randInt(0, totalWeight - 1);
            while(index >= weightFunc.Invoke(weightedList[i]))
            {               
                index -= weightFunc.Invoke(weightedList[i]);
                i++;
            }
            return weightedList[i];
        }
    }
}
