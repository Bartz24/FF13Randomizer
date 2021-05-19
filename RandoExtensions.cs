using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FF13Data
{
    public static class RandoExtensions
    {
        public static double CubeRoot(double x)
        {
            if (x < 0)
                return -Math.Pow(-x, 1d / 3d);
            else
                return Math.Pow(x, 1d / 3d);
        }

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = RandomNum.RandInt(0, n);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public static void Shuffle<T>(this IList<T> list, Action<T, T> swapFunc)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = RandomNum.RandInt(0, n);
                swapFunc.Invoke(list[n], list[k]);
            }
        }

        public static IList<T> ShuffleWeighted<T>(this IList<T> list, IList<int> weights)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < list.Count; i++)
            {
                for (int w = 0; w < weights[i]; w++)
                    map.Add(map.Count, i);
            }
            List<int> shuffled = Enumerable.Range(0, map.Count).ToList().Shuffle().ToList();
            list = Enumerable.Range(0, map.Count).Select(i => list[map[shuffled[i]]]).ToList();
            return list;
        }
    }
}
