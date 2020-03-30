using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class TieredManager<T>
    {
        public List<Tiered<T>> list = new List<Tiered<T>>();

        public List<Tiered<T>> GetTiered(int rank, int count)
        {
            return list.Where(t => rank >= t.LowBound && rank <= t.GetHighBound(count)).ToList();
        }

        public Tuple<T,int> Get(int rank, int maxCount, Func<Tiered<T>,int> weightFunc = null)
        {
            if (weightFunc == null)
                weightFunc = t => t.Weight;
            List<Tiered<T>> items = GetTiered(rank, maxCount);
            Tiered<T> tiered = RandomNum.SelectRandomWeighted(items, weightFunc);
            return Get(rank,tiered);
        }

        public Tuple<T, int> Get(int rank, Tiered<T> tiered, Func<T, bool> meetsReq = null)
        {
            List<Tuple<T, int>> possible = tiered == null ? new List<Tuple<T, int>>() : tiered.Get(rank,meetsReq);
            if (possible.Count == 0)
                return new Tuple<T, int>(default(T), 0);
            return possible[RandomNum.RandInt(0, possible.Count - 1)];
        }

        public int GetRank(T obj, int count=1)
        {
            int avg = 0, avgCount = 0;
            foreach(Tiered<T> tiered in list)
            {
                int rank = tiered.GetRank(obj, count);
                if (rank != -1)
                {
                    if (count > 99)
                        Console.WriteLine(tiered.GetRank(obj, count));
                    avg += rank;
                    avgCount++;
                }
                    
            }
            return avgCount == 0 ? -1 : (int)Math.Round((float)avg / avgCount);
        }
    }
}
